using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandlePanel : State {

	public HandlePanel(GameObject own): base(own){
		
	}



	// Use this for initialization
	void Start () {
		Vector3 dest = owner.GetComponent<Agent>().Objectives.GetBestObjectivePosition();
		owner.GetComponent<NavMeshAgent>().destination=dest;
	}
	
	// Update is called once per frame
	void Update () {
		if (owner.GetComponent<Agent>().Vision.SenseAny())
            {
                HashSet<Transform> objects_in_view = owner.GetComponent<Agent>().Vision.SensedObjects;
                foreach (Transform t in objects_in_view)
                {
                    Interactable inte = t.GetComponent<Interactable>();
                    if (inte.Type == Goal.Objective_T.PANEL && inte.ID == owner.GetComponent<Agent>().Objectives.Queue[0].Id)
                    { // check ID et classe necessaire pour le trap
                        
						// Lecture
						Agent ag =owner.GetComponent<Agent>();
						foreach(Interactable I in (inte as Panel).Info){
							ag.Objectives.AddGoal(new Goal(I,ag),ag);
						}

                    }

                }
            }
	}
}
