using UnityEngine;

public class CarTurnLeft : CarTurn
{
    protected bool isChange = true;
    private void OnTriggerEnter(Collider other)
    {
        if (controller.CarMoving.isBackMove == false)
        {
            if (other.gameObject.CompareTag("Left") && isChange == true)
            {
                SetRotate(-90);
                isChange = false;
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Left") && isChange == false)
            {
                SetRotate(90);
                isChange = true;
            }
        }
    }
}
