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
    public float JumpForce;
    

	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
    }
	
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

	    if (Input.GetKeyDown("space") && isGrounded)
	    {
            rb.AddForce(Vector2.up * JumpForce);
	        isGrounded = false;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(JumpDelay());
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {

    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(0.4F);
        isGrounded = false;
    }
}
