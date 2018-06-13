using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToObj : State {


    bool once = true;

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


        if (own.Vision.SenseAny()) // On met vraiment le else ???
        {
            HashSet<Transform> objects_in_view = own.Vision.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                
                Interactable inte = t.GetComponent<Interactable>();
                
                if (inte.Type == Goal.Objective_T.TRAP)
                { // check ID et classe necessaire pour le trap
                    if (!own.Objectives.ContainsGoal(inte.ID))
                    {
                        Debug.Log("Piege !");
                        Goal g = new Goal(inte , own);
                        owner.GetComponent<Agent>().New_Objectives.AddGoal(g, own);
                        owner.GetComponent<Agent>().Objectives.AddGoal(0, g, own);
                        own.StateMachine.ChangeState();
                    }
                    else if(once)
                    {
                        Debug.Log("Piege connu!");
                        once = false;
                        own.Objectives.PutGoalDown(own.Objectives.Queue[0], own);
                        break;
                    }
                }else if (inte.Type == Goal.Objective_T.PANEL){
                    // check ID et classe necessaire pour le panel
                    if (!own.Objectives.ContainsGoal(inte.ID))
                    {
                        Debug.Log("PANNEAU !");
                        Goal g = new Goal(inte, own);
                        owner.GetComponent<Agent>().Objectives.AddGoal(0, g, own);
                        owner.GetComponent<Agent>().New_Objectives.AddGoal(g, own);
                        own.StateMachine.ChangeState();
                    }
                }
            }
            //own.Objectives.SortByPriority();
            
        }
	 }

	override
	public void Exit(){
		 
	 }
	
    public void UpdateDestination()
    {
        Vector3 dest = owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
        owner.GetComponent<NavMeshAgent>().destination = dest;
    }

}
