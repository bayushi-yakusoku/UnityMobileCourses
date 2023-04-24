using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);

            string msg = string.Concat(
                    "Screen is pressed at position: ", screenPosition, "\n",
                    "Convertion to World position : ", worldPosition
                );

            Debug.Log(msg);
        }
    }
}
