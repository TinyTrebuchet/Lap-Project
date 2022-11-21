using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using Unity.MLAgents; 
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class BotLearning : Agent
{
    
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform targetTransform1;

    [SerializeField] private Transform targetTransform2;
    [SerializeField] private Transform targetTransform3;
    [SerializeField] private float moveSpeed = 1;


    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(0.0f,0.5f,0.0f);
    }

    public override void  CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(targetTransform.position);
        sensor.AddObservation(targetTransform1.position);
        sensor.AddObservation(targetTransform2.position);
        sensor.AddObservation(targetTransform3.position);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
        continuousActions[2] = 0.0f;
        Debug.Log(continuousActions[0]);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float rotateY = actions.ContinuousActions[2];
        Debug.Log(moveX);
        transform.position += new Vector3(moveX,0,moveZ) * Time.deltaTime * moveSpeed;

        transform.Rotate(Vector3.up, rotateY * Mathf.Rad2Deg * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(+1f);
            EndEpisode();
        }

        if(other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            EndEpisode();
        }
    }
	
}
