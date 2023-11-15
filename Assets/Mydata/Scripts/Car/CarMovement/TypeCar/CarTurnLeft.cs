using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurnLeft : CarTurn
{
    protected override void ResetValue()
    {
        base.ResetValue();
        nameTrafficPoint = "Left";
    }
}
