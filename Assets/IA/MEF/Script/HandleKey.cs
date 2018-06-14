using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandleKey : State
{

    Vector3 dest;

    public HandleKey(GameObject own) : base(own)
    {

    }
    override
    public void Enter()
    {
        if (owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition() != null)
        {
            dest = owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
            owner.GetComponent<NavMeshAgent>().destination = dest;
        }
        else
        {
            owner.GetComponent<Agent>().FirstGoalIsOver();
            owner.GetComponent<Agent>().StateMachine.ChangeToGoHome();
        }
        
    }
    override
    public void Execute()
    {

            if (owner.GetComponent<Agent>().entity.AttackRange.SenseAny())
            {
                HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().entity.AttackRange.SensedObjects;
                foreach (Transform t in objects_in_view)
                {
                    Interactable inte = t.GetComponent<Interactable>();
                    if (inte.Type == Goal.Objective_T.KEY && inte.ID == owner.GetComponent<Agent>().Objectives.Queue[0].Id)
                    { // check ID et classe necessaire pour le trap
                        owner.GetComponent<Agent>().FirstGoalIsOver();
                        GameObject.Destroy(inte.gameObject);
                        owner.GetComponent<Agent>().StateMachine.ChangeToGoHome();
                        break;
                    }
                }
            }else if(owner.transform.position == dest){
                owner.GetComponent<Agent>().FirstGoalIsOver();
                owner.GetComponent<Agent>().StateMachine.ChangeToGoHome();
            }


    }
    override
    public void Exit()
    {

    }


}
