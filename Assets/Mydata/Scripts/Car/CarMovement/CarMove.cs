using UnityEngine;

public class CarMove : MyMonoBehavior
{
    [SerializeField] protected CarController controller;
    [SerializeField] protected Vector3 initialPosition;
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float speed = 7.0f;

    public int currentWaypointIndex = 0;

    protected override void Start()
    {
        base.Start();
        SetPosStart();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCarContrl();
    }

    protected virtual void LoadCarContrl()
    {
        if (controller != null) return;
        controller = GetComponent<CarController>();
    }

    protected virtual void SetPosStart()
    {
        initialPosition = transform.position;
        if (waypoints.Length > 0)
        {
            waypoints[0].position = initialPosition;
        }
    }
    protected virtual void FixedUpdate()
    {
        Move();

        LookAtPoint();

        ChangePoint();

        ActiveCar();
    }

    protected virtual void ActiveCar()
    {
        if (controller.CheckTouchForMovement.isTouch == true && transform.position == initialPosition)
        {
            currentWaypointIndex++;
            controller.Checker.isBack = false;
        }
    }

    protected virtual void ChangePoint()
    {
        float distanceToTarget = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (distanceToTarget < 0.1f)
        {
            if (controller.Checker.isBack == false)
            {
                if (currentWaypointIndex < waypoints.Length - 1)
                {
                    currentWaypointIndex++;
                }
            }
            else
            {
                if (currentWaypointIndex > 0)
                {
                    currentWaypointIndex--;
                }
                else
                {
                    currentWaypointIndex = 0;
                }
            }
        }
    }

    protected virtual void LookAtPoint()
    {
        if (controller.Checker.isBack == false)
        {
            transform.LookAt(waypoints[currentWaypointIndex].position);
        }
        else
        {
            transform.LookAt(waypoints[currentWaypointIndex + 1].position);
        }
    }

    protected virtual void Move()
    {
        if (waypoints.Length == 0) return;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.fixedDeltaTime);
        
    }
}
