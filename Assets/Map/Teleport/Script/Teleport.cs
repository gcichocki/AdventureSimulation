using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour {

    [SerializeField] Transform destination;


    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<NavMeshAgent>().ResetPath();
        if (destination != null)
        {
            other.gameObject.GetComponent<NavMeshAgent>().Warp(destination.position);
            other.gameObject.GetComponent<Agent>().StateMachine.ChangeStateAfterTP();

        }
    }
           

    // Use this for initialization
}
