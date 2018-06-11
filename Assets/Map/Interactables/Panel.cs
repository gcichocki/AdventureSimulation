using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Interactable {

	[SerializeField]List<Interactable> info;

	

    public List<Interactable> Info { get { return info;} set {info = value;}}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
