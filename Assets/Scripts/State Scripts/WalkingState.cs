using SolarStudios;
using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI; //important

public class WalkingState : MonoBehaviour, IState
{
    private StateMachine stateMachine;
    private Animator anim;
    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in

    Vector3 point;
    public void Enter(StateMachine stateMachine) //Runs when we enter the state
    {
        this.stateMachine = stateMachine;
        anim = stateMachine.anim;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("We just entered walk");

       
        if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
        {
           // Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
            agent.SetDestination(point);
        }
        anim.SetInteger("Walk", 1);
    }
    public void Run() //Runs every frame
    {
        if (Vector3.Distance(agent.transform.position, point) <= agent.stoppingDistance)
        {
            Debug.Log("We made it");
            stateMachine.SetState(stateMachine.GetComponent<IdleState>());
        }
        /*if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            return;
        */

    }
    public void Exit() //Runs when we exit
    {
        anim.SetInteger("Walk", 0);
        Debug.Log("We just exited walk");
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
