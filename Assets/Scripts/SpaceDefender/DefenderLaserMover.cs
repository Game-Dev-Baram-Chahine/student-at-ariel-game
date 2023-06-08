using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderLaserMover : MonoBehaviour
{
    [SerializeField] public float speed = 10f;  // Speed of the laser
    [SerializeField] public string enemyTag = "Enemy";  // Tag of the enemy objects
    //[SerializeField] public int borderUp;

    private void Update()
    {
        // Move the laser upward
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Destroy the laser if it goes off-screen
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            // Handle the collision with the enemy
            Destroy(other.gameObject);  // Destroy the enemy
            Destroy(gameObject);  // Destroy the laser
            

            
        }
    }
}
