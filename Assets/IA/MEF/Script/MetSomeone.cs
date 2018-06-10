using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetSomeone : State  {

    Agent sender;

	public MetSomeone(GameObject own): base(own){
	}

	override
	public void Enter(){
        sender = owner.GetComponent<Agent>();
    }

	override
	public void Execute(){
        if (sender.Discussion.SenseAny())
        {
            HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Discussion.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                Message msg = new Message(sender, t.gameObject.GetComponent<Agent>(), Message.Message_T.GOT_INFORMATION);
                msg.SendMessage();
            }
            owner.GetComponent<Agent>().Objectives.SortByPriority();
            owner.GetComponent<Agent>().StateMachine.ChangeState();
        }
        sender.StateMachine.ChangeState();
    }
	override
	public void Exit(){
		 
	 }
}
