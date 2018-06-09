using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToObj : State {

	public GoToObj(GameObject own): base(own){
		
	}

	override
	public void Enter(){
		Vector3 dest =owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
	 }
	override
	public void Execute(){
		 
	 }
	override
	public void Exit(){
		 
	 }
	override
	public void ReceiveMessage( Goal message ){
	}
}
