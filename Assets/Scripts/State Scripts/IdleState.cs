using SolarStudios;
using UnityEngine;
using UnityEngine.AI; //important

public class IdleState : MonoBehaviour, IState
{
    private StateMachine stateMachine;
    public NavMeshAgent agent;
    private Animator anim;

    public float timer;
    public float maxTimer;


    public void Enter(StateMachine stateMachine) //Runs when we enter the state
    {
        anim = stateMachine.anim;
        Debug.Log("We just entered Idle");
        this.stateMachine = stateMachine;
        agent = GetComponent<NavMeshAgent>();

        

    }

    public void Run() //Runs every frame
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            stateMachine.SetState(stateMachine.GetComponent<WalkingState>());
            timer = maxTimer;
        }
    }

    public void Exit() //Runs when we exit
    {
        Debug.Log("We just exited Idle");
    }
}
