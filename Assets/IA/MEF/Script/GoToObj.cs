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
		owner.GetComponent<Agent>().Vision.SenseAny();
		HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Vision.SensedObjects;
		foreach(GameObject in objects_in_view)
	 }
	override
	public void Exit(){
		 
	 }
	
}
