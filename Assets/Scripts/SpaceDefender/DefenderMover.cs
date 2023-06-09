using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefenderMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveVertical = new InputAction(type: InputActionType.Button);

    [SerializeField] float borderL;
    [SerializeField] float borderR;
    [SerializeField] float borderD;

    [SerializeField] public string enemyTag = "Enemy";  // Tag of the enemy objects
    void OnEnable()
    {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }


    void Update()
    {
        float horizontal = moveHorizontal.ReadValue<float>();
        float vertical = moveVertical.ReadValue<float>();
        Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        if (transform.position.y > borderD)
        {
            transform.position += movementVector;
        }
        else
        {
            movementVector = new Vector3(horizontal, -borderD, 0) * speed * Time.deltaTime;
            transform.position += movementVector;
        }
        if (transform.position.x > borderL)
        {
            transform.position = new Vector3(borderR, transform.position.y, transform.position.z);
        }
        if (transform.position.x < borderR)
        {
            transform.position = new Vector3(borderL, transform.position.y, transform.position.z);
        }

        //transform.Translate(movementVector);
        // NOTE: "Translate(movementVector)" uses relative coordinates - 
        //       it moves the object in the coordinate system of the object itself.
        // In contrast, "transform.position += movementVector" would use absolute coordinates -
        //       it moves the object in the coordinate system of the world.
        // It makes a difference only if the object is rotated.
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.CompareTag(enemyTag))
        {
            // Handle the collision with the enemy
            Destroy(other.gameObject);  //Destroy the enemy
            Destroy(gameObject);//Destroy the Player
            StaticVariables.LoadSceneByName("DefenderIntor");
        }
    }
}

