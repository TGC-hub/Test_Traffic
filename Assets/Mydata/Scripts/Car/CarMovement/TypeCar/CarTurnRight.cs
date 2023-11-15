using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurnRight : CarTurn
{
    protected override void ResetValue()
    {
        base.ResetValue();
        nameTrafficPoint = "Right";
    }
}
