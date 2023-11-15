using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CheckTrafficPoint : MyMonoBehavior
{
    [SerializeField] public bool isTurn = false;

    [SerializeField] public bool isReturn = false;
    [SerializeField] protected string nameTrafficPoint;

    [SerializeField] protected CarController controller;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(nameTrafficPoint))
        {
            if(controller.CarMoving.isBackMove == true) { isReturn = true; isTurn = false; }
            else { isTurn = true; isReturn = false;  }
        }
    }

}
