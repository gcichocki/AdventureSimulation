using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalQueue {

    List<Goal> queue;
    bool once = true;
    public List<Goal> Queue { get { return queue; } set { queue = value; } }

    public GoalQueue()
    {
        this.queue = new List<Goal>();
    }

    public void SortByPriority()
    {
        queue.Sort();
    }

   /* void Start()
    {
        this.queue = new List<Goal>();
        Goal c = new Goal(Goal.Objective_T.TRAP, null, BaseEntity.Class_T.HUNTER);
        queue.Add(c);
        Goal g = new Goal(Goal.Objective_T.TRAP, null, BaseEntity.Class_T.FIGHTER);
        queue.Add(g);
        Goal a = new Goal(Goal.Objective_T.RELIC, null, BaseEntity.Class_T.ALL);
        queue.Add(a);
        Goal b = new Goal(Goal.Objective_T.KEY, null, BaseEntity.Class_T.ALL);
        queue.Add(b);
        Goal d = new Goal(Goal.Objective_T.TRAP, null, BaseEntity.Class_T.HEALER);
        queue.Add(d);
    }

    void Update()
    {
        SortByPriority();
        if (once)
        {
            foreach (Goal g in queue)
            {
                Debug.Log(g);
            }
            once = false;
        }
        
        
    }*/

}
