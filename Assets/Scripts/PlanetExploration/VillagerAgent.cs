using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class VillagerAgent : Agent
{
    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    Vector3 startPosition = new Vector3(8.54f, -1.41f, -1f);
    [SerializeField]
    Vector3 playerStartPosition = new Vector3(8.54f, -1.41f, -1f);
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private float speed = 3f;
    public override void OnEpisodeBegin()
    {
        rb.transform.localPosition = startPosition;
        playerRb.transform.localPosition = playerStartPosition;
    }
    // Collect the observations for the agent and the target (terrain in this case)
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }
    // This method is for rewarding the player and ending the episode.
    public void RewardUpdate(float reward)
    {
        AddReward(reward);
        EndEpisode();
    }
    // This method is for controlling the rigidbody in the episode
    public override void OnActionReceived(ActionBuffers actions)
    {
        int moveY = actions.DiscreteActions[0];
        int moveX = actions.DiscreteActions[1];
        Vector3 movement = Vector3.zero;
        if (moveY == 2)
        {
            movement = Vector3.up;
        }
        else if (moveY == 1)
        {
            movement = Vector3.down;
        }
        else if (moveX == 2)
        {
            movement = Vector3.right;
        }
        else if (moveX == 1)
        {
            movement = Vector3.left;
        }
        // Debug.Log("Move: " + movement);
        transform.position = transform.position + movement * Time.deltaTime * speed;
    }
    // This method gets the inputs from the user in the Heuristic mode and translates it to the discrete actions array.
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.A))
            discreteActions[1] = 1;
        if (Input.GetKey(KeyCode.D))
            discreteActions[1] = 2;
        if (Input.GetKey(KeyCode.W))
            discreteActions[0] = 2;
        if (Input.GetKey(KeyCode.S))
            discreteActions[0] = 1;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Success");
            RewardUpdate(1.0f);
        }
    }
}