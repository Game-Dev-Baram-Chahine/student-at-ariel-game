using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderLaserEnemy : MonoBehaviour
{
    [SerializeField] public float speed = 10f;  // Speed of the laser
    [SerializeField] public string enemyTag = "Player";  // Tag of the enemy objects

    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;
    [SerializeField] private float spawnCooldown = 1f;

    [SerializeField] public int maxRandomNum = 7;
    int diceRoll;
    public static float lastSpawnTime = 0f;

    /*void OnEnable()
    {
        spawnAction.Enable();
    }

    void OnDisable()
    {
        spawnAction.Disable();
    }*/

    protected virtual GameObject spawnObject()
    {
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
        return newObject;
    }

    private void Update()
    {
        bool canSpawn = Time.time > lastSpawnTime + spawnCooldown;
        diceRoll = UnityEngine.Random.Range(1, maxRandomNum);
        if (canSpawn && (diceRoll == 1))
        {
            spawnObject();
            lastSpawnTime = Time.time;
        }

        // Move the laser upward
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the laser if it goes off-screen
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.CompareTag(enemyTag))
        {
            // Handle the collision with the enemy
            Destroy(other.gameObject);  //Destroy the enemy
            Destroy(gameObject);//Destroy the laser
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.CompareTag(enemyTag))
        {
            // Handle the collision with the enemy
            Destroy(other.gameObject);  //Destroy the enemy
            Destroy(gameObject);//Destroy the laser
        }
    }
}
