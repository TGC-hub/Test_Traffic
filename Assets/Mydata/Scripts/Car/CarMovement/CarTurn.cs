using UnityEngine;

public class CarTurn : MyMonoBehavior
{
    protected float rotateSpeed = 15f;
    protected float setRos;
    [SerializeField] protected CarController controller;

    protected override void Start()
    {
        base.Start();
        setRos = transform.eulerAngles.y;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCarCtrl();
    }

    protected virtual void LoadCarCtrl()
    {
        if (this.controller != null) { return; }
        else
        {
            this.controller = GetComponent<CarController>();
        }
    }

    protected virtual void SetRotate(int rotate)
    {
        setRos = transform.eulerAngles.y + rotate;
    }

    protected virtual void QuaternionY()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, setRos, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
    }

    protected virtual void FixedUpdate()
    {
        QuaternionY();
    }
}
