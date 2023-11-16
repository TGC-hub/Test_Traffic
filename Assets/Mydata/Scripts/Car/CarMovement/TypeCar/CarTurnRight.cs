
using UnityEngine;

public class CarTurnRight : CarTurn
{
    protected bool isChange = true;
    private void OnTriggerEnter(Collider other)
    {
        if (controller.CarMoving.isBackMove == false)
        {
            if (other.gameObject.CompareTag("Right") && isChange == true)
            {
                SetRotate(90);
                isChange = false;
                Debug.Log("OK MAN");
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Right") && isChange == false)
            {
                SetRotate(-90);
                isChange = true;
                Debug.Log("OK MAN BACK");
            }
        }
    }
}
