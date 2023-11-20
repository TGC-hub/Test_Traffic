using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private Vector3 worldPos;
    public Vector3 WorldPos => worldPos;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }
    void Update()
    {
        TouchInput();
    }

    protected virtual void TouchInput()
    {
        // Android
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                float xPosition = touch.position.x;
                float zPosition = touch.position.y;

                Vector3 screenPos = new Vector3(xPosition, zPosition, 50f);
                worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                StartCoroutine(ResetPos());
            }
        }

        // Unity editor, PC
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 50f));
            StartCoroutine(ResetPos());
        }
    }

    private IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(0.1f);
        float xPosition = 100f;
        float zPosition = 100f;
        Vector3 screenPos = new Vector3(xPosition, zPosition, 50f);
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);
    }

}
