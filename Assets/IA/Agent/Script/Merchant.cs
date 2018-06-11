using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : Agent {

	

	
	
  	public override bool GotInformation()
    {
        
        bool res = false;                  // Need to handle the heal case later
        if(Objectives.Queue.Count > 0 && timer < 0) //entity.NeedHeal() || New_Objectives.Queue.Count > 0)
        {
            res = true;
        }
        return res;
    }

     public override void AddNewGoal(Goal g, Agent owner)
    {
        if (!Objectives.ContainsGoal(g.Id))
        {
            Objectives.AddGoal(g, owner);
        }
        else
        {
            if (g.Concern != owner.Objectives.Content[g.Id].Concern)
            {
                owner.Objectives.Content[g.Id].Concern = g.Concern;
            }
        }
        New_Objectives.Queue = new List<Goal>(Objectives.Queue);
        New_Objectives.Content = new Dictionary<int, Goal>(Objectives.Content);
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
