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
        if (owner.GetComponent<Agent>().Vision.SenseAny())
        {
            HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Vision.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                if (t.tag.Equals("TRAP"))
                { // check ID et classe necessaire pour le trap
                    if (owner.GetComponent<Agent>().Objectives.ContainsGoal(t.transform.GetComponent<Trap>().ID))
                    {
                        Goal g = new Goal(Goal.Objective_T.TRAP, t, BaseEntity.Class_T.ALL);
                        owner.GetComponent<Agent>().New_Objectives.AddGoal(g);
                        owner.GetComponent<Agent>().Objectives.AddGoal(g);
                    }
                }


            }
            owner.GetComponent<Agent>().Objectives.SortByPriority();
            owner.GetComponent<Agent>().StateMachine.ChangeState();
        }
	 }

	override
	public void Exit(){
		 
	 }
	
}
