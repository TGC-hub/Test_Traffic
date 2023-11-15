using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHuman : MyMonoBehavior
{
    [SerializeField] public bool isHuman = false;
    [SerializeField] protected float distanceTarget = 5f;

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
    protected virtual void FixedUpdate()
    {
        RayChecker();
    }

    protected virtual void RayChecker()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, distanceTarget))
        {
            if (hit.collider.CompareTag("Human"))
            {
                isHuman = true;
                Debug.Log("Human");
            }
        }
    }
}
