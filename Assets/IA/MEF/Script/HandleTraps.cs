using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandleTraps : State  {

    float timer = 3.0f;
    float reset_timer = 3.0f;

    bool try_disarm = false;
    Interactable to_disarm;

	public HandleTraps(GameObject own): base(own){
		
	}
	override
	public void Enter(){
		Vector3 dest = owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
	 }
	override
	public void Execute(){
        // Gestion disarm
        // Le disarm se fait dans un autre script et on check içi si le trap est disarmed

        // On fait le disarm içi et on check quand le trap est disarmed
        // Necessaire d'avoir acces à AttackRange(j'imagine)
        if (try_disarm)
        {
            Disarm();
        }
        else
        {
            if (owner.GetComponent<Agent>().entity.AttackRange.SenseAny())
            {
                HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().entity.AttackRange.SensedObjects;
                foreach (Transform t in objects_in_view)
                {
                    Interactable inte = t.GetComponent<Interactable>();
                    if (inte.Type == Goal.Objective_T.TRAP && inte.ID == owner.GetComponent<Agent>().Objectives.Queue[0].Id)
                    { // check ID et classe necessaire pour le trap
                        try_disarm = true;
                        to_disarm = inte;
                    }

                }
            }
        }
        
		
	 }
	override
	public void Exit(){
		 
	 }

    void Disarm()
    {
        timer -= Time.deltaTime;
        if (timer < 0f && try_disarm)
        {
            if(to_disarm.Concern == owner.GetComponent<Agent>().entity.Class)
            {

                owner.GetComponent<Agent>().FirstGoalIsOver();
                GameObject.Destroy(to_disarm.gameObject);
            }
            else
            {
                owner.GetComponent<Agent>().entity.Health -= 20 ;
                to_disarm = null;
                timer = reset_timer;
            }
            
            try_disarm = false;
            //Car on renre à la taverne, on va forcément sort
            //owner.GetComponent<Agent>().Objectives.SortByPriority();
            owner.GetComponent<Agent>().StateMachine.ChangeToGoHome();
        }
    }
}
