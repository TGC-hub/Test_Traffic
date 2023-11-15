using UnityEngine;

public class CarMoving : MyMonoBehavior
{
    [SerializeField] protected float moveSpeed = 7.0f;
    public float MoveSpeed => moveSpeed;

    protected CarController controller;

    protected Vector3 startCarPos;

    public bool isBackMove = false;

    protected override void Start()
    {
        base.Start();
        startCarPos = transform.position;
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
    protected virtual void FixedUpdate()
    {
        Moving();
        DistanceCar();
    }

    protected virtual void DistanceCar()
    {
        float distance = Vector3.Distance(startCarPos, transform.position);
        if(distance < 1f) { isBackMove = false;}
    }

    protected virtual void Moving()
    {
        if (controller.CheckTouchForMovement.isTouch == true) { CanMove();}
        if(isBackMove == true) { BackMove();}
    }
    protected virtual void CanMove()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
    }

    protected virtual void BackMove()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            isBackMove = true;
            controller.CheckTouchForMovement.isTouch = false;
        }
    }

    
}
