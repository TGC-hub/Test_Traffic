using UnityEngine;

public class CarController : MyMonoBehavior
{
    [SerializeField] protected CarMove carMove;
    public CarMove CarMove => carMove;

    [SerializeField] protected CheckTouchForMovement checkTouchForMovement;
    public CheckTouchForMovement CheckTouchForMovement => checkTouchForMovement;

    [SerializeField] protected Checker checker;
    public Checker Checker => checker;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCarMoving();
        LoadCheckTouch();
        LoadChecker();
    }

    protected virtual void LoadChecker()
    {
        if (checker != null) { return; }
        this.checker = GetComponentInChildren<Checker>();
    }

    protected virtual void LoadCarMoving()
    {
        if (this.carMove != null) { return; }
        else
        {
            this.carMove = GetComponent<CarMove>();
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
