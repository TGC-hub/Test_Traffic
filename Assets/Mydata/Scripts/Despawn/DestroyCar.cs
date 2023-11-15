using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    [SerializeField] protected float disLimit = 50f;
    [SerializeField] protected float distance = 0f;
    protected Vector3 startPos;
    private void Start()
    {
        startPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        CanDespawn();
    }
    protected virtual void CanDespawn()
    {
        distance = Vector3.Distance(transform.position, startPos);
        if (distance < disLimit) return;
        else { Destroy(this.transform.parent.gameObject); }
    }


}
