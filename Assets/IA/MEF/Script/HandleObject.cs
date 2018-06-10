using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandleObjects : State {


	public HandleObjects(GameObject own): base(own){
		
	}


	override
	public void Enter(){
		Vector3 dest =owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
	 }
	override
	public void Execute(){

		// Discussion ou AttackRange[BaseEntity](necessite d'enlever la protection dessus)
		owner.GetComponent<Agent>().Discussion.SenseAny();
		HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Discussion.SensedObjects;
		
		foreach(Transform t in objects_in_view){
			if(true){ // ce serait cool de connaitre l'id de l'objet (histoire de pas se tromer d'objet)
				// Ajout de l'objet à l'inventaire
				
				// Destruction de l'objet sur la map

				// Peut être reflexion sur ce que l'on equipe?


				// Objectif final terminé
					// Besoin de Destroy le Goal?
					
				owner.GetComponent<Agent>().Objectives.Queue.RemoveAt(0);


				owner.GetComponent<Agent>().StateMachine.ChangeState();
			}


		}
	 }
	override
	public void Exit(){
		 
	 }
}
