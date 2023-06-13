using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    public Transform endGame;
    public float speed;
    public float force = 15.0f;
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
        CheckGameStatus();
    }
    private void FixedUpdate()
    {
        Vector2 velocity = transform.right * (moveX * speed);
        rb.AddForce(velocity);
        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));
        if (direction > 0)
        {
            rb.rotation += moveY * rotation * (rb.velocity.magnitude / speed);
        }
        else
        {
            rb.rotation -= moveY * rotation * (rb.velocity.magnitude / speed);
        }
        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * force;
        Vector2 relativeForce = Vector2.up * thrustForce;
        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision2D: " + other.collider.tag);
        StaticVariables.LoadSceneByName("AirPlane-StartScreen");
    }
    /// <summary>
    /// This function Checks if the player got to the target location.
    /// </summary>
    private void CheckGameStatus()
    {
        if (transform.position.x >= endGame.position.x)
        {
            StaticVariables.LoadSceneByName("AirPlane-WonScreen");
        }
    }
}
