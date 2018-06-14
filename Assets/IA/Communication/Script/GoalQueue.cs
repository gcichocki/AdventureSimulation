using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoalQueue {

    Agent owner;

    [SerializeField] List<Goal> queue;
    Dictionary<int, Goal> content;



    bool once = true;
    public List<Goal> Queue { get { return queue; } set { queue = value; } }
    public Dictionary<int, Goal> Content { get { return content; } set { content = value; } }

    public GoalQueue(Agent own)
    {
        this.owner = own;
        this.queue = new List<Goal>();
        this.content = new Dictionary<int, Goal>();
    }

    public void SortByPriority(Agent a)
    {
        //UpdateOwner(owner);
        owner = a;
        //List<Goal> sorted = new List<Goal>(queue);
        //sorted.Sort();
        //queue = new List<Goal>(sorted);
        queue.Sort();

    }

    public bool ContainsGoal(int id)
    {
        return content.ContainsKey(id);
    }

    public void AddGoal(Goal g, Agent owner)
    {
        if (!ContainsGoal(g.Id))
        {
            g.Owner = owner;
            queue.Add(g);
            content.Add(g.Id, g);
        }
        
    }

    public void AddGoal(int index, Goal g, Agent owner)
    {
        if (!ContainsGoal(g.Id))
        {
            g.Owner = owner;
            queue.Insert(index, g);
            content.Add(g.Id, g);
        }

    }

    public void PutGoalDown(Goal g , Agent owner){
        Debug.Log("Changing Obj with same level");
        // Check if we got this Goal
        if (!ContainsGoal(g.Id)){
            Debug.Log("Trying to PutDown a non-present Goal");
        } else {
            int j = this.queue.IndexOf(g);
            int i = j + 1;

            while(i<queue.Capacity-1 && g.CompareToNormal(queue[i])==0){
                i++;
            }
            queue.Insert(i,g);
            queue.RemoveAt(j);

            if(queue[j] == g)
            {
                owner.StateMachine.ChangeToGoHome();
            }
            else
            {
                owner.StateMachine.ChangeState();
            }
        }

    }

    public void UpdateOwner(Agent a)
    {
        foreach(Goal g in queue)
        {
            g.Owner = a;
        }
    }

    public void Reset()
    {
        this.queue = new List<Goal>();
        this.content = new Dictionary<int, Goal>();
    }

    public void RemoveGoal(Goal g)
    {
        if (ContainsGoal(g.Id))
        {
            queue.Remove(g);
            content.Remove(g.Id);
        }
    }

    public Vector3 GetBestObjectivePosition()
    {
        if (queue[0].Location.position != null)
        {
            return queue[0].Location.position;
        }
        else
        { 
            return queue[1].Location.position;
        }
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
