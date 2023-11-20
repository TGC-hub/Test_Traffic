using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MyMonoBehavior
{
    [SerializeField] protected CarController controller;
    public bool isBack = false;
    public int ValueTrigge = 0;

    protected override void Start()
    {
        base.Start();
        isBack = true;
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
            this.controller = GetComponentInParent<CarController>();
        }
    }

    protected virtual void FixedUpdate()
    {
        if(controller.CarMove.currentWaypointIndex == 0)
        {
            ValueTrigge = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && ValueTrigge == 0 && controller.CarMove.currentWaypointIndex != 0)
        {
            isBack = true;
            ValueTrigge++;
            controller.CarMove.currentWaypointIndex--;
        }

        if (other.gameObject.CompareTag("Human"))
        {
            Time.timeScale = 0;
        }
    }


}
