using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarStudios;
using UnityEngine.AI; //important

public class IdleState : MonoBehaviour, IState
{
    private StateMachine stateMachine;
    public NavMeshAgent agent;
    public bool waiting;
    float time;
    float resetTime;
    public Transform centrePoint;
    float range;

    public void Enter(StateMachine stateMachine) //Runs when we enter the state
    {
        Debug.Log("We just entered Idle");
        this.stateMachine = stateMachine;
        agent = GetComponent<NavMeshAgent>();

        // Set up the time and waiting variables
        waiting = false;
        resetTime = 5.0f;
        time = resetTime;

        // Start waiting for 5 seconds
        StartCoroutine(WaitAndTransition());
    }

    public void Run() //Runs every frame
    {
        // Idle state logic goes here
    }

    public void Exit() //Runs when we exit
    {
        Debug.Log("We just exited Idle");
    }

    IEnumerator WaitAndTransition()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        // Transition to the "Walking" state
        stateMachine.SetState(stateMachine.GetComponent<WalkingState>());
    }

    /*bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        // Random point logic
    }
    */
}
