using System.Collections;
using UnityEngine;

public class CarTurnAroundRight : CarTurn
{
    protected bool isChange = true;
    protected int turnValue = 0;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (controller.CarMoving.distancePointStart < 1f) { isChange = true; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (controller.CarMoving.isBackMove == false)
        {
            if (other.gameObject.CompareTag("Right") && isChange == true)
            {
                SetRotate(90);
                isChange = false;
                StartCoroutine(SetTurnValue());
                Debug.Log("OK Right");
            }

            if (other.gameObject.CompareTag("Left") && turnValue == 1)
            {
                SetRotate(90);
                turnValue = 0;
                Debug.Log("OK Left");
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Left") && isChange == false)
            {
                SetRotate(-90);
                isChange = true;
                StartCoroutine(SetTurnValue());
                Debug.Log("OK MAN");
            }

            if (other.gameObject.CompareTag("Right") && turnValue == 1)
            {
                SetRotate(-90);
                turnValue = 0;
                Debug.Log("OK MAN BACK");
            }
        }
    }

    private IEnumerator SetTurnValue()
    {
        yield return new WaitForSeconds(1f);
        turnValue++;
    }
}
