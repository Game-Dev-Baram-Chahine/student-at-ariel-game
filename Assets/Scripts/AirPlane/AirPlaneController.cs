using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    public float speed;
    public float acceleration;
    Rigidbody2D rb;
    public float rotation;
    // Start is called before the first frame update
    private float moveX, moveY = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        Vector2 velocity = transform.right * (moveX * speed);
        rb.AddForce(velocity);
        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));
        if (acceleration > 0)
        {
            if (direction > 0)
            {
                rb.rotation += moveY * rotation * (rb.velocity.magnitude / speed);
            }
            else
            {
                rb.rotation -= moveY * rotation * (rb.velocity.magnitude / speed);
            }
        }
        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;
        Vector2 relativeForce = Vector2.up * thrustForce;
        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
