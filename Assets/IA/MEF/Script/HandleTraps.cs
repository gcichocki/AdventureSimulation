using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandleTraps : State  {

	public HandleTraps(GameObject own): base(own){
		
	}
	override
	public void Enter(){
		Vector3 dest =owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
	 }
	override
	public void Execute(){
		 // Gestion disarm
			// Le disarm se fait dans un autre script et on check içi si le trap est disarmed

			// On fait le disarm içi et on check quand le trap est disarmed
				// Necessaire d'avoir acces à AttackRange(j'imagine)
		
		owner.GetComponent<Agent>().Discussion.SenseAny();
		HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Discussion.SensedObjects;
		foreach(Transform t in objects_in_view){
			if(t.tag.Equals("TRAP")){ 
				// On tente le disarm
			}

		}
	 }
	override
	public void Exit(){
		 
	 }
}
