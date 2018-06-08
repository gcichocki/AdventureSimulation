using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour {

	NavMeshAgent agent ;

	public Transform goal;
	Transform previous_goal;

	// Use this for initialization
	void Start () {
		agent=gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(previous_goal==null){
			if(goal!=null){
				previous_goal=goal;
				agent.destination=goal.position;
			}
		}
		else if(goal.position!=previous_goal.position){
			previous_goal=goal;
			agent.destination=goal.position;
		}
	}
}
