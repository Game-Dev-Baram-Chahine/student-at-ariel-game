using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefenderLaserSpawner : MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;
    [SerializeField] private float spawnCooldown = 0.5f;

    public static float lastSpawnTime = 0f;

    void OnEnable()
    {
        spawnAction.Enable();
    }

    void OnDisable()
    {
        spawnAction.Disable();
    }

    protected virtual GameObject spawnObject()
    {
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
        return newObject;
    }

    private void Update()
    {
        // Check if spawn is available
        bool canSpawn = Time.time > lastSpawnTime + spawnCooldown;
        if (canSpawn && spawnAction.WasPressedThisFrame())
        {
            spawnObject();
            lastSpawnTime = Time.time;
        }
    }
}
