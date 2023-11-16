﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastChecker : MyMonoBehavior
{
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
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        float maxRaycastDistance = 2f;

        if (Physics.Raycast(ray, out hit, maxRaycastDistance) )
        {
            if (hit.collider.gameObject.CompareTag("Car"))
            {
                controller.CarMoving.isBackMove = true;
                controller.CheckTouchForMovement.isTouch = false;
            }
            if (hit.collider.gameObject.CompareTag("Human"))
            {
                Time.timeScale = 0.0f;
            }
        }
    }
}
