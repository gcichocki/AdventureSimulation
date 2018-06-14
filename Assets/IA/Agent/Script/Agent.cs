using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public  class Agent : MonoBehaviour {

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
    protected float timer = 0.0f;
    public float TimerInfo { get { return timer; } set { timer = value; } }


    [SerializeField]protected GoalQueue objectives;
    public GoalQueue Objectives { get { return objectives; } set { objectives = value; } }

    [SerializeField]GoalQueue new_objectives;
    public GoalQueue New_Objectives { get { return new_objectives; } set { new_objectives = value; } }


    protected StateMachine stateMachine;
    public StateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }

    bool once = true;

    // Use this for initialization
    void Start () {
        Objectives = new GoalQueue(this);
        Goal g = new Goal(Relic, this);
        Objectives.AddGoal(g, this);
        New_Objectives = new GoalQueue(this);
        

        stateMachine = new StateMachine(this);
        Discussion.Initialize();
        Vision.Initialize();
        entity.AttackRange.Initialize();
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

    virtual public  void AddNewGoal(Goal g, Agent owner)
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

    virtual public void GetNewInformationFrom(Agent sender)
    {
        foreach (Goal g in sender.New_Objectives.Queue)
        {
            AddNewGoal(g, sender);
        }
        sender.New_Objectives.Reset();
        Objectives.SortByPriority();
    }

    public void GetNewInformationFrom(Merchant sender)
    {
        Objectives.Queue = new List<Goal>(sender.Objectives.Queue);
        Objectives.Content = new Dictionary<int, Goal>(sender.Objectives.Content);
        Objectives.SortByPriority();
        New_Objectives.Reset();
    }

    virtual public bool GotInformation()
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

    virtual public void PrintGoals()
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
