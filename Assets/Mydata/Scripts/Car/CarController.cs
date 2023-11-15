using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MyMonoBehavior
{
    [SerializeField] protected CarMoving carMoving;
    public CarMoving CarMoving => carMoving;

    [SerializeField] protected CheckTouchForMovement checkTouchForMovement;
    public CheckTouchForMovement CheckTouchForMovement => checkTouchForMovement;

    [SerializeField] protected CheckTrafficPoint checkTraffic;
    public CheckTrafficPoint CheckTraffic => checkTraffic;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCarMoving();
        LoadCheckTouch();
        LoadCheckTraffic();
    }

    protected virtual void LoadCheckTraffic()
    {
        if (this.checkTraffic != null) { return; }
        else
        {
            this.checkTraffic = GetComponentInChildren<CheckTrafficPoint>();
        }
    }

    protected virtual void LoadCarMoving()
    {
        if (this.carMoving != null) { return; }
        else
        {
            this.carMoving = GetComponent<CarMoving>();
        }
    }

    protected virtual void LoadCheckTouch()
    {
        if (this.checkTouchForMovement != null) { return; }
        else
        {
            this.checkTouchForMovement = GetComponentInChildren<CheckTouchForMovement>();
        }
    }

}
