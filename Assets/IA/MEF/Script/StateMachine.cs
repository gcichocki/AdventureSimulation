using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {


	//a pointer to the agent that owns this instance
  	Agent	owner;

  	[SerializeField] State   current_state;
  
  	//a record of the last state the agent was in
  	[SerializeField] State   previous_state;

	// Update is called once per frame
	void Update () {
		if(current_state!=null){
			current_state.Execute();
		}
	}

	public void ChangeState(){
		Goal g = owner.Objectives.Queue[0];
		switch(g.Type){
			case Goal.Objective_T.TRAP :
			break;
			case Goal.Objective_T.MONSTER :
			break;
			case Goal.Objective_T.RELIC :
			break;
			case Goal.Objective_T.KEY :
			break;
			
		}
	}

	public void HandleMessage(Agent sender, Agent receiver, Message.Message_T message)
    {
        switch (message)
        {
            case Message.Message_T.GOT_INFORMATION:
                //do something
                break;
            case Message.Message_T.NEED_HEAL:
                break;
        }
    }
}
