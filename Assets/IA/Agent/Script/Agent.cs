using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    [Header("Entity Variables")]
    public BaseEntity entity;

	[SerializeField] Transform homeTP;
    [SerializeField] Transform home;
    [SerializeField] Transform dungeonEntranceTP;
    [SerializeField] Transform dungeonEntrance;
    [SerializeField] Interactable relic;
	[SerializeField] Sensor vision;
	[SerializeField] Sensor discussion;

    [SerializeField] float time_to_share_info = 10.0f;
    float timer = 0.0f;
    public float TimerInfo { get { return timer; } set { timer = value; } }


    [SerializeField] GoalQueue objectives;
    public GoalQueue Objectives { get { return objectives; } set { objectives = value; } }

    GoalQueue new_objectives;
    public GoalQueue New_Objectives { get { return new_objectives; } set { new_objectives = value; } }


    StateMachine stateMachine;
    public StateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }

    bool once = true;

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
        
        /*if (this.gameObject.tag.Equals("HEALER"))
        {
            Goal c = new Goal(Goal.Objective_T.TRAP, null, BaseEntity.Class_T.HUNTER, this);
            Goal g = new Goal(Goal.Objective_T.TRAP, null, BaseEntity.Class_T.FIGHTER, this);
            Goal a = new Goal(Goal.Objective_T.RELIC, null, BaseEntity.Class_T.ALL, this);
            Goal b = new Goal(Goal.Objective_T.KEY, null, BaseEntity.Class_T.ALL, this);
            Goal d = new Goal(Goal.Objective_T.TRAP, null, BaseEntity.Class_T.HEALER, this);

            AddNewGoal(a, this);
            AddNewGoal(b, this);
            AddNewGoal(c, this);
            AddNewGoal(d, this);
            AddNewGoal(g, this);

            Objectives.SortByPriority();
            
        }
        if (this.gameObject.tag.Equals("HUNTER"))
        {
            Goal c = new Goal(Goal.Objective_T.RELIC, null, BaseEntity.Class_T.ALL, this);

            AddNewGoal(c, this);


            Objectives.SortByPriority();

        }*/

    }
	


	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        StateMachine.Update();
    }

    public void FirstGoalIsOver()
    {

        //remove de tout les goals
        Goal g = this.Objectives.Queue[0];
        if (New_Objectives.ContainsGoal(g.Id))
        {
            New_Objectives.RemoveGoal(g);
        }
        Objectives.Queue[0].Concern = BaseEntity.Class_T.NOBODY;
        New_Objectives.AddGoal(Objectives.Queue[0], this);
        Objectives.SortByPriority();
    }

    public void AddNewGoal(Goal g, Agent owner)
    {
        if (!Objectives.ContainsGoal(g.Id))
        {
            New_Objectives.AddGoal(g, owner);
            Objectives.AddGoal(g, owner);
        }
        else
        {
            if(g.Concern != owner.Objectives.Content[g.Id].Concern)
            {
                owner.Objectives.Content[g.Id].Concern = g.Concern;
            }
        }
    }

    public void GetNewInformationFrom(Agent sender)
    {
        foreach (Goal g in sender.New_Objectives.Queue)
        {
            AddNewGoal(g, sender);
        }
        Objectives.SortByPriority();
       /* if (once && Objectives.Queue.Count > 0)
        {
            foreach (Goal g in Objectives.Queue)
            {
                Debug.Log(g);
            }
            once = false;
        }*/
    }

    public bool GotInformation()
    {
        
        bool res = false;                  // Need to handle the heal case later
        if(New_Objectives.Queue.Count > 0 && timer < 0) //entity.NeedHeal() || New_Objectives.Queue.Count > 0)
        {
            res = true;
        }
        return res;
    }

    public void ResetTimerInfo()
    {
        TimerInfo = time_to_share_info;
    }

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

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Discussion.DrawGizmos();
        Vision.DrawGizmos();
        entity.AttackRange.DrawGizmos();
    }
#endif

    public Transform Home
    {
        get
        {
            return home;
        }

        set
        {
            home = value;
        }
    }

    public Transform DungeonEntrance
    {
        get
        {
            return dungeonEntrance;
        }

        set
        {
            dungeonEntrance = value;
        }
    }

    public Interactable Relic
    {
        get
        {
            return relic;
        }

        set
        {
            relic = value;
        }
    }

    public Sensor Vision
    {
        get
        {
            return vision;
        }

        set
        {
            vision = value;
        }
    }

    public Sensor Discussion
    {
        get
        {
            return discussion;
        }

        set
        {
            discussion = value;
        }
    }

    public Transform HomeTP
    {
        get
        {
            return homeTP;
        }

        set
        {
            homeTP = value;
        }
    }

    public Transform DungeonEntranceTP
    {
        get
        {
            return dungeonEntranceTP;
        }

        set
        {
            dungeonEntranceTP = value;
        }
    }
}
