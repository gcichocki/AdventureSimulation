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

	void ChangeState(){

	}

	public void HandleMessage( Goal message ){

	}
}
