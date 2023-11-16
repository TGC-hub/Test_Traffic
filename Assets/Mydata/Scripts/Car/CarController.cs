using UnityEngine;

public class CarController : MyMonoBehavior
{
    [SerializeField] protected CarMoving carMoving;
    public CarMoving CarMoving => carMoving;

    [SerializeField] protected CheckTouchForMovement checkTouchForMovement;
    public CheckTouchForMovement CheckTouchForMovement => checkTouchForMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCarMoving();
        LoadCheckTouch();
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
