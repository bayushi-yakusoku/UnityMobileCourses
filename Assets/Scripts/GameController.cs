using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] Rigidbody2D pivotPoint;
    [SerializeField] GameObject prefabBall;

    private GameObject currentBall;
    private Rigidbody2D currentBallBody;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            // Prevent the current ball from being affectede by physics
            currentBallBody.isKinematic = true;

            Vector2 screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            string msg = string.Concat(
                    "Screen is pressed at position: ", screenPosition, "\n",
                    "Convertion to World position : ", worldPosition
                );

            Debug.Log(msg);

            if (float.IsInfinity(screenPosition.x) || float.IsInfinity(screenPosition.y))
            {
                Debug.Log("Infinity detected!");
                return;
            }

            currentBallBody.position = worldPosition;
        }
        else
        {
            // current ball should be affected by physics
            currentBallBody.isKinematic = false;
        }
    }

    void SpawnBall()
    {
        currentBall = Instantiate(prefabBall, pivotPoint.position, Quaternion.identity);

        currentBallBody = currentBall.GetComponent<Rigidbody2D>();
        SpringJoint2D currentBallJoint = currentBall.GetComponent<SpringJoint2D>();

        currentBallJoint.connectedBody = pivotPoint;
    }
}
