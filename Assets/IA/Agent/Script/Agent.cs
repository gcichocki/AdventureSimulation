using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    [Header("Entity Variables")]
    public BaseEntity entity;

	[SerializeField] Transform home;
    [SerializeField] Transform dungeonEntrance;
    [SerializeField] Transform relic;
	[SerializeField] Sensor vision;
	[SerializeField] Sensor discussion;




    GoalQueue objectives;
    public GoalQueue Objectives { get { return objectives; } set { objectives = value; } }

    GoalQueue new_objectives;
    public GoalQueue New_Objectives { get { return new_objectives; } set { new_objectives = value; } }


    StateMachine stateMachine;
    public StateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


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

    public Transform Relic
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

}
