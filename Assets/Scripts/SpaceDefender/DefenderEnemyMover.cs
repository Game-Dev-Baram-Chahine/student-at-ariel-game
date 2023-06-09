using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderEnemyMover : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;  // Horizontal movement speed
    [SerializeField] public float descendSpeed = 5f;  // Vertical descent speed
    [SerializeField] public float border = 7f;  // Vertical descent speed

    [SerializeField] private bool movingRight = true;  // Flag indicating if the enemy is moving right

    private void Update()
    {
        // Calculate the horizontal movement direction based on the movingRight flag
        float horizontalMovement = movingRight ? 1f : -1f;

        // Move the enemy horizontally
        transform.Translate(Vector3.right * horizontalMovement * moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the far left or far right
        if (transform.position.x <= -border)
        {
            movingRight = true;  // Switch movement direction to right
            MoveDown();  // Move the enemy down
        }
        else if (transform.position.x >= border)
        {
            movingRight = false;  // Switch movement direction to left
            MoveDown();  // Move the enemy down
        }
        else
            MoveDown();
    }

    private void MoveDown()
    {
        // Move the enemy down vertically
        transform.Translate(Vector3.down * descendSpeed * Time.deltaTime);
    }
}
