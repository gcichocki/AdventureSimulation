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
        if(own.entity.AttackRange.SenseAny()){
            HashSet<Transform> objects_in_view = own.entity.AttackRange.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                Interactable inte = t.GetComponent<Interactable>();
                if (inte.Type == Goal.Objective_T.TRAP ) // On a juste besoin de savoir si il y a piege
                { 
                    // Repousser le goal actuel en dernier (de son classement)
                    own.Objectives.PutGoalDown(own.Objectives.Queue[0],own);
                    
                }
            }
        }
        else if (own.Vision.SenseAny()) // On met vraiment le else ???
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
                       
                        Goal g = new Goal(inte , own);
                        //owner.GetComponent<Agent>().New_Objectives.AddGoal(g, own); // ptetre pas necessaire (c'est du consommable)
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
