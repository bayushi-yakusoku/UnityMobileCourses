using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D body;
    private SpringJoint2D joint;

    float thrust = 0f;
    public float Thrust
    {
        get => thrust;
        set
        {
            thrust = value;
        }
    }

    Vector2 target;
    public Vector2 Target
    {
        get => target;
        set
        {
            target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
    }

    public Vector2 Position
    {
        get => body.position;
        set
        {
            body.position = value;
        }
    }

    public Rigidbody2D ConnectedBody
    {
        get => joint.connectedBody;
        set
        {
            joint.enabled = true;

            if (joint.connectedBody == value) 
                return;

            joint.connectedBody = value;
        }
    }

    public void Launch()
    {
        body.isKinematic = false;
        body.AddForce((target - body.position) * thrust, ForceMode2D.Impulse);
    }
}
