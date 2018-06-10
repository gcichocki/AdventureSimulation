using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToObj : State {

	public GoToObj(GameObject own): base(own){
		
	}

	override
	public void Enter(){
		Vector3 dest = owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
	 }

	override
	public void Execute(){
        Agent own = owner.GetComponent<Agent>();
        if (own.Vision.SenseAny())
        {
            
            HashSet<Transform> objects_in_view = own.Vision.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                Debug.Log("Un truc ?");
                Interactable inte = t.GetComponent<Interactable>();
                Debug.Log(inte.ID);
                if (inte.Type == Goal.Objective_T.TRAP && !own.Objectives.ContainsGoal(inte.ID))
                { // check ID et classe necessaire pour le trap
                    Debug.Log("OH UN TRAP");
                    if (!own.Objectives.ContainsGoal(inte.ID))
                    {
                        Goal g = new Goal(inte , own);
                        Debug.Log("OH UN PIEGE PTDR");
                        owner.GetComponent<Agent>().New_Objectives.AddGoal(g, own);
                        owner.GetComponent<Agent>().Objectives.AddGoal(0, g, own);
                    }
                }


            }
            
            //own.Objectives.SortByPriority();
            own.StateMachine.ChangeState();
        }
	 }

	override
	public void Exit(){
		 
	 }
	
}
