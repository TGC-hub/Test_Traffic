using System.Collections;
using UnityEngine;

public class CheckTouchForMovement : MyMonoBehavior
{
    [SerializeField] protected float disLimit = 1.0f;
    [SerializeField] protected float distance = 0.0f;
    public bool isTouch = false;
    protected virtual void FixedUpdate()
    {
        CheckDistance();
    }
    protected virtual void CheckDistance()
    {
        distance = HorizontalDistance(this.transform.position, InputManager.Instance.WorldPos);
        if (distance < disLimit) { isTouch = true;}
    }

    protected float HorizontalDistance(Vector3 position1, Vector3 position2)
    {
        position1.y = 0;
        position2.y = 0;

        return Vector3.Distance(position1, position2);
    }



}
