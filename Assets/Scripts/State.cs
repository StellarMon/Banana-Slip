using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Update()
    {
        yield break;
    }

    public virtual IEnumerator RandomPoint()
    {
        yield break;
    }

    // protected Agent agent;
    // protected StateMachine stateMachine;

    //public State (Agent agent, StateMachine stateMachine)
    

    // public virtual void EnterState() ()
    // public virtual void ExitState() ()
}