using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override State RunCurrentState();
    {
        return this;
    }
}
