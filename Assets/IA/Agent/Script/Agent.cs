using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    [Header("Entity Variables")]
    public BaseEntity entity;

	[SerializeField] Transform Home;
    [SerializeField] Transform DungeonEntrance;
    [SerializeField] Transform Relic;
	[SerializeField] Sensor Vision;
	[SerializeField] Sensor Discussion;


    GoalQueue objectives;
    public GoalQueue Objectives { get { return objectives; } set { objectives = value; } }

    GoalQueue new_objectives;
    public GoalQueue New_Objectives { get { return new_objectives; } set { new_objectives = value; } }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
