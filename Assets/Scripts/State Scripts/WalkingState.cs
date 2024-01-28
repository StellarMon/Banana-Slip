using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important
using SolarStudios;

public class WalkingState : MonoBehaviour, IState
{
    private StateMachine stateMachine;
    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    public float time = 0.0f;
    public float ResetTime = 5.0f;

    public bool waiting;
    private IEnumerator delay;
        public void Enter(StateMachine stateMachine) //Runs when we enter the state
        {
            this.stateMachine = stateMachine;
            //
            agent = GetComponent<NavMeshAgent>();
            Debug.Log("We just entered walk");
        }
        public void Run() //Runs every frame
        {
 if (agent.remainingDistance > agent.stoppingDistance) //done with path
            return;
        if (!waiting)
        {
            waiting = true;
            time = ResetTime;

        }

        time -= Time.deltaTime;
        if (time > 0)
        {
            return;
        }

        Vector3 point;
        waiting = false;

        if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
            agent.SetDestination(point);
        }
        }
        public void Exit() //Runs when we exit
        {
            Debug.Log("We just exited walk");
        }

        bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
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