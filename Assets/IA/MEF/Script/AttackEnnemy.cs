using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnnemy : State  {


	public AttackEnnemy(GameObject own): base(own){
		
	}
	
	public void Enter( GameObject ennemy){
		Vector3 dest =owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
		
	 }
	override
	public void Execute(){
		// Gestion comportement
			// Check vie , fatigue ect...

			// On tire les conclusions
		
		// Gestion combat
			// Le combat se fait dans un autre script et on check içi si l'ennemi est mort

			// On fait le combat içi et on check quand l'ennemi est mort
				// Necessaire d'avoir acces à AttackRange
		
		owner.GetComponent<Agent>().Discussion.SenseAny();
		HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Discussion.SensedObjects;
		foreach(Transform t in objects_in_view){
			if(t.tag.Equals("MONSTER")){ 

			}

		}
	 }
	override
	public void Exit(){
		 
	 }
}
