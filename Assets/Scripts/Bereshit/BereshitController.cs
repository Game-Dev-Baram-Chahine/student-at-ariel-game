using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component simulates the controls of a spaceship that should land on the moon without exploding.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class BereshitController : MonoBehaviour
{
    [SerializeField]
    float thrustForce = 10f;

    [SerializeField]
    float torqueForce = 10f;

    [SerializeField]
    InputAction noseForce = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction tailForce = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction rightAngleTorque = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction leftAngleTorque = new InputAction(type: InputActionType.Button);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        noseForce.Enable();
        tailForce.Enable();
        rightAngleTorque.Enable();
        leftAngleTorque.Enable();
    }

    void OnDisable()
    {
        noseForce.Disable();
        tailForce.Disable();
        rightAngleTorque.Disable();
        leftAngleTorque.Disable();
    }

    /* To prevent explosion - send a ray to the moon and "drag" the spaceship when the moon is nearby: */
    private void Update()
    {
        // Get the values of the right and left angle torque inputs.
        float rightAngle = rightAngleTorque.ReadValue<float>();
        float leftAngle = leftAngleTorque.ReadValue<float>();
        // Calculate the impulse.
        // The impulse is the torque applied to the spaceship.
        var impulse =
            (leftAngle * torqueForce * Mathf.Deg2Rad - rightAngle * torqueForce * Mathf.Deg2Rad)
            * rb.inertia;
        // Apply the impulse to the spaceship.
        rb.AddTorque(impulse, ForceMode2D.Impulse);

        float nose = noseForce.ReadValue<float>();
        float tail = tailForce.ReadValue<float>();
        // Calculate the force applied to the spaceship.
        // The force is calculated by multiplying the thrust force by the nose and tail values.
        // The nose value is 1 if the player is pressing the arrow up, and 0 if he is not.
        // The tail value is 1 if the player is pressing the arrow down, and 0 if he is not.
        // Apply the force to the spaceship.
        rb.AddForce(transform.up * thrustForce * nose, ForceMode2D.Force);
        rb.AddForce(Vector2.down * thrustForce * tail, ForceMode2D.Force);
    }
}
