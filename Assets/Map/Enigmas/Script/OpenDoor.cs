using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    [SerializeField] Interactable key1;
    [SerializeField] Interactable key2;
    [SerializeField] Interactable key3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(key1 == null && key2 == null && key3 == null)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
