using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager : MonoBehaviour
{
    protected State State;

    public void SetState(State state)
    {
        State = state;
        StartCoroutine(routine:State.Start());
    }

    // public StateManager CurrentState {get, set;}

    // public void Initialize(StateManager startingState)
   
}