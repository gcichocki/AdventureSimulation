using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetSomeone : State  {

    Agent sender;

    bool metMerchant = false;

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
                if (t.gameObject.GetComponent<Agent>().entity.Class == BaseEntity.Class_T.MERCHANT)
                {
                    Debug.Log("Oh un marchand");
                    metMerchant = true;
                    Message msg = new Message(sender, t.gameObject.GetComponent<Merchant>() as Merchant, Message.Message_T.GOT_INFORMATION);
                    msg.SendMessageToMerchant(t.gameObject.GetComponent<Merchant>() as Merchant);

                    Message msgM = new Message(t.gameObject.GetComponent<Merchant>() as Merchant, sender , Message.Message_T.GOT_INFORMATION);
                    msgM.SendMessageFromMerchant(t.gameObject.GetComponent<Merchant>() as Merchant);
                }
                else{
                    Message msg = new Message(sender, t.gameObject.GetComponent<Agent>(), Message.Message_T.GOT_INFORMATION);
                    msg.SendMessage();
                }
            }
            owner.GetComponent<Agent>().Objectives.SortByPriority(owner.GetComponent<Agent>());
        }

        if (metMerchant)
        {
            sender.StateMachine.ChangeToGoDungeon();
        }
        else
        {
            sender.StateMachine.ChangeState();
        }
        
    }
	override
	public void Exit(){
		 
	 }
}
