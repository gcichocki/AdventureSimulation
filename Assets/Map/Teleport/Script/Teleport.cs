using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [SerializeField] Transform destination;


    void OnTriggerEnter(Collider other)
    {
        if(destination!=null)
            other.gameObject.transform.position = destination.position;
    }

    // Use this for initialization
}
