﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {


	//a pointer to the agent that owns this instance
  	Agent	owner;

  	[SerializeField] State   current_state;
  
  	//a record of the last state the agent was in
  	[SerializeField] State   previous_state;

    public State Current_state
    {
        get
        {
            return current_state;
        }

        set
        {
            current_state = value;
        }
    }

    public StateMachine(Agent own)
    {
        owner = own;
        current_state = new GoToObj(own.gameObject);
    }

    // Update is called once per frame
    public void Update () {
		if(current_state!=null ){
            current_state.Execute();
            if(!(Current_state is HandleTraps))
            {
                HandleFriends();
            }
           
        }
       
    }

	public void ChangeState(){
        previous_state = current_state;

        if(owner.Objectives.Queue.Count!=0){
			Goal g = owner.Objectives.Queue[0];
			switch(g.Type){
				case Goal.Objective_T.TRAP :
                    
                    current_state.Exit();
                    current_state=new HandleTraps(owner.gameObject);
                    
				break;
				case Goal.Objective_T.MONSTER :
                    
                    current_state.Exit();
                    current_state=new AttackEnnemy(owner.gameObject);                    
				break;
				case Goal.Objective_T.RELIC :
                    
                    if(previous_state is GoToObj)
                    {
                        (current_state as GoToObj).UpdateDestination();
                    }
                    else
                    {
                        current_state.Exit();
                        current_state = new GoToObj(owner.gameObject);
                    }
				break;
				case Goal.Objective_T.KEY :
                    if (previous_state is GoToObj)
                    {
                        (current_state as GoToObj).UpdateDestination();
                    }
                    else
                    {
                        current_state.Exit();
                        current_state = new GoToObj(owner.gameObject);
                    }

                    break;
                case Goal.Objective_T.PANEL :
                    current_state.Exit();
                    current_state=new HandlePanel(owner.gameObject);
                break;
                default:
                    if (current_state != previous_state)
                    {
                        previous_state.Exit();
                    }
                break;
            }
        }
		else{
			previous_state=current_state;
			current_state.Exit();
			current_state=new GoHome(owner.gameObject);
			current_state.Enter();
		}   
    }

    public void ChangeStateAfterTP()
    {
        if (owner.gameObject.transform.position == owner.Home.position)
        {
            ChangeToGoDungeon();
        }
        else
        {
            ChangeState();
        }
    }

    public void ChangeToGoHome()
    {
        previous_state = current_state;
        current_state.Exit();
        current_state = new GoHome(owner.gameObject);
        current_state.Enter();
    }

    public void ChangeToKey()
    {
        previous_state = current_state;
        current_state.Exit();
        current_state = new HandleKey(owner.gameObject);
        current_state.Enter();
    }

    public void ChangeToGoDungeon()
    {
        previous_state = current_state;
        current_state.Exit();
        current_state = new GoDungeon(owner.gameObject);
        current_state.Enter();
    }

    public void HandleFriends()
    {
        previous_state = current_state;
        //Handle the change to state MetSomeone if the agent got information to share
        if (owner.GetComponent<Agent>().Discussion.SenseAny() && owner.GotInformation())
        {
            current_state = new MetSomeone(owner.gameObject);
            owner.GetComponent<Agent>().ResetTimerInfo();
        }
        else if (owner.GetComponent<Agent>().Discussion.SenseAny())
        {
            HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Discussion.SensedObjects;
            foreach (Transform t in objects_in_view)
            {
                Agent a = t.gameObject.GetComponent<Agent>();
                if (a.StateMachine.Current_state is HandleTraps)
                {
                    a.Objectives.PutGoalDown(a.Objectives.Queue[0], a);
                }
                else
                {
                    owner.Objectives.UpdateOwner(owner);
                    //Debug.Log("SOOOOOOOOORT");
                    //a.Objectives.SortByPriority();
                }
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

    public void HandleMessage(Agent sender, Merchant receiver, Message.Message_T message)
    {
        switch (message)
        {
            case Message.Message_T.GOT_INFORMATION:
                receiver.GetNewInformationFrom(sender);

                break;
        }
    }

    public void HandleMessage(Merchant sender, Agent receiver, Message.Message_T message)
    {
        switch (message)
        {
            case Message.Message_T.GOT_INFORMATION:
                receiver.GetNewInformationFrom(sender);

                break;
        }
    }
}
