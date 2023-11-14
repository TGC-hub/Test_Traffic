using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        TouchInput();
    }

    protected virtual void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                float xPosition = touch.position.x;
                float zPosition = touch.position.y;

                Vector3 screenPos = new Vector3(xPosition, zPosition, 50f); 
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

                Debug.Log("Touched at position - X: " + worldPos.x + ", Z: " + worldPos.z);
            }
        }
    }
}
