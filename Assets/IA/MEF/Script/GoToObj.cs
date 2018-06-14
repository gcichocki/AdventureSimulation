using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToObj : State {


    bool once = true;
    float timer = 1.5f;
    float reset_timer = 1.5f;
    float count = 0 ;


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

        KnownTrapsTimer();
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
                        own.Objectives.SortByPriority();
                        count++;
                        once = false;
                        own.Objectives.PutGoalDown(own.Objectives.Queue[0], own);
                        if (count > 3)
                        {
                            own.StateMachine.ChangeToGoHome();
                        }
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


    void KnownTrapsTimer()
    {
        if (!once)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                once = true;
                timer = reset_timer;
            }

        }
    }
}
