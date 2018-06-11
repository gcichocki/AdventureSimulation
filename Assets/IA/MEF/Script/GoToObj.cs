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
                Interactable inte = t.GetComponent<Interactable>();
                if (inte.Type == Goal.Objective_T.TRAP && !own.Objectives.ContainsGoal(inte.ID))
                { // check ID et classe necessaire pour le trap
                    if (!own.Objectives.ContainsGoal(inte.ID))
                    {
                        Debug.Log("Piege !");
                        Goal g = new Goal(inte , own);
                        owner.GetComponent<Agent>().New_Objectives.AddGoal(g, own);
                        owner.GetComponent<Agent>().Objectives.AddGoal(0, g, own);
                    }
                }
                 if (inte.Type == Goal.Objective_T.PANEL)
                { // check ID et classe necessaire pour le trap
                    // Y voit pas le paneau !
                    if (!own.Objectives.ContainsGoal(inte.ID))
                    {
                        Debug.Log("Informations !");
                        Goal g = new Goal(inte , own);
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
