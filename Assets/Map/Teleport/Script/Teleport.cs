using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour {

    [SerializeField] Transform destination;


    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        if (destination != null)
        {
            other.gameObject.transform.position = destination.position;
        }
        other.gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }
           

    // Use this for initialization
}
