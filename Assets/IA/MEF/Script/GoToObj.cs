using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToObj : State {

	public GoToObj(GameObject own): base(own){
		
	}

	override
	public void Enter(){
		//Vector3 dest =owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		//owner.GetComponent<NavMeshAgent>().destination=dest;
	 }

	override
	public void Execute(){
        Agent own = owner.GetComponent<Agent>();
        /*if (own.Vision.SenseAny())
        {
            HashSet<Transform> objects_in_view = own.Vision.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                if (t.tag.Equals("TRAP"))
                { // check ID et classe necessaire pour le trap
                    if (own.Objectives.ContainsGoal(t.transform.GetComponent<Trap>().ID))
                    {
                        Goal g = new Goal(Goal.Objective_T.TRAP, t, BaseEntity.Class_T.ALL, own);
                        owner.GetComponent<Agent>().New_Objectives.AddGoal(g, own);
                        owner.GetComponent<Agent>().Objectives.AddGoal(g, own);
                    }
                }


            }
            own.Objectives.SortByPriority();*/
        own.StateMachine.ChangeState();
        //}
	 }

	override
	public void Exit(){
		 
	 }
	
}
