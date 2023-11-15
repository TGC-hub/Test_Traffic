using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurn : CheckTrafficPoint
{
    protected float rotateSpeed = 7.0f;
    [SerializeField] protected float rotateY;
    [SerializeField] protected float reRotateY;

    protected virtual void SetRotate(float rotate)
    {
        Quaternion targetRotation = Quaternion.Euler(0f, rotate, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
    }

    protected virtual void FixedUpdate()
    {
        if (isTurn == true)
        {
            SetRotate(rotateY);
        }
        if(isReturn ==  true)
        {
            SetRotate(reRotateY);
        }
    }
}
