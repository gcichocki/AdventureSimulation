using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : Agent {

	

	// Use this for initialization
	
	void Start () {
		Objectives = new GoalQueue(this);
        New_Objectives = new GoalQueue(this);
        Goal g = new Goal(Relic, this);
        AddNewGoal(g, this);

        stateMachine = new StateMachine(this);
        Discussion.Initialize();
        Vision.Initialize();
        entity.AttackRange.Initialize();
	}
	
	// Update is called once per frame
	
	void Update () {
		timer-=Time.deltaTime;
		StateMachine.HandleDiscussion();
	}

	
	
  	public override bool GotInformation()
    {
        
        bool res = false;                  // Need to handle the heal case later
        if(Objectives.Queue.Count > 0 && timer < 0) //entity.NeedHeal() || New_Objectives.Queue.Count > 0)
        {
            res = true;
        }
        return res;
    }

	override
    public void GetNewInformationFrom(Agent sender)
    {
        foreach (Goal g in sender.New_Objectives.Queue)
        {
            AddNewGoal(g, sender);
        }
        //Objectives.ClearMind();
       
    }

	override
	public void PrintGoals()
    {
        if (Objectives.Queue.Count > 0)
        {
            foreach (Goal g in Objectives.Queue)
            {
                Debug.Log(g);
            }
        }
    }


}
