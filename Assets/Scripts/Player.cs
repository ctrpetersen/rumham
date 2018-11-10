using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;

    public float Thrust;
    public float MovThrust;
    public float MaxAngularVelocity;
    

	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKey("a"))
	    {
            rb.AddTorque(Thrust);
            rb.AddForce(Vector2.left * MovThrust);
	    }
        else if (Input.GetKey("d"))
	    {
	        rb.AddTorque(-Thrust);
	        rb.AddForce(Vector2.right * MovThrust);
        }
	}

    void FixedUpdate()
    {
        ClampAngularVelocity();
    }

    void ClampAngularVelocity()
    {
        if (rb.angularVelocity < -MaxAngularVelocity) { rb.angularVelocity = -MaxAngularVelocity; }
        if (rb.angularVelocity > MaxAngularVelocity) { rb.angularVelocity = MaxAngularVelocity; }
    }
}
