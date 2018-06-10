using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {


	//a pointer to the agent that owns this instance
  	Agent	owner;

  	[SerializeField] State   current_state;
  
  	//a record of the last state the agent was in
  	[SerializeField] State   previous_state;

    public StateMachine(Agent own)
    {
        owner = own;
        current_state = new GoToObj(own.gameObject);
    }

    // Update is called once per frame
    public void Update () {
		if(current_state!=null){
            Debug.Log(current_state.ToString());
            current_state.Execute();
		}
	}

	public void ChangeState(){
        previous_state = current_state;
        //Handle the change to state MetSomeone if the agent got information to share
        if (owner.GetComponent<Agent>().Discussion.SenseAny() && owner.GotInformation())
        {
            Debug.Log("INFO ENVOYEE");
            current_state = new MetSomeone(owner.gameObject);
            owner.GetComponent<Agent>().ResetTimerInfo();
        }

        if(current_state == previous_state)
        {
            current_state = new GoToObj(owner.gameObject);
            //Handle the changing state to the best possible goal
            Goal g = owner.Objectives.Queue[0];
            switch (g.Type)
            {
                case Goal.Objective_T.TRAP:
                    break;
                case Goal.Objective_T.MONSTER:
                    break;
                case Goal.Objective_T.RELIC:
                    break;
                case Goal.Objective_T.KEY:
                    break;

            }
        }

        if (current_state != previous_state)
        {
            previous_state.Exit();
        }
            
    }

	public void HandleMessage(Agent sender, Agent receiver, Message.Message_T message)
    {
        switch (message)
        {
            case Message.Message_T.GOT_INFORMATION:
                receiver.GetNewInformationFrom(sender);
                
                break;
            case Message.Message_T.NEED_HEAL:
                break;
        }
    }
}
