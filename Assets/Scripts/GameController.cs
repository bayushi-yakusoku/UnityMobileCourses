using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] Rigidbody2D pivotPoint;
    [SerializeField] GameObject prefabBall;

    private GameObject currentBall;
    private BallController currentBallController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (currentBall is null)
            {
                SpawnBall();
            }

            MoveBall();
        }
        else
        {
            if (currentBall)
            {
                // current ball should be affected by physics
                currentBallController.Launch();
                currentBall = null;
            }
        }
    }

    void SpawnBall()
    {
        currentBall = Instantiate(prefabBall, pivotPoint.position, Quaternion.identity);

        currentBallController = currentBall.GetComponent<BallController>();
        currentBallController.ConnectedBody = pivotPoint;
        currentBallController.Position = Vector2.zero;
    }

    void MoveBall()
    {
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

        currentBallController.Position = worldPosition;

    }
}
