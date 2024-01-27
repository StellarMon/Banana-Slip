using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppedState : State
{
    public override State RunCurrentState();
    {
        return this;
    }
}
