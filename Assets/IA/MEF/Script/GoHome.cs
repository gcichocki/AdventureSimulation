using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoHome : State  {

	public GoHome(GameObject own): base(own){
        
    }

	override
	public void Enter(){
        Vector3 dest = owner.GetComponent<Agent>().Home.position;
        owner.GetComponent<NavMeshAgent>().destination = dest;
    }

	override
	public void Execute(){
		 
	}
	override
	public void Exit(){
		 
	}



}
