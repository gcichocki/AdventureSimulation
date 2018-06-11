using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoHome : State  {


	public GoHome(GameObject own): base(own){
        
    }

	override
	public void Enter(){
        Vector3 dest = owner.GetComponent<Agent>().HomeTP.position;
        owner.GetComponent<NavMeshAgent>().destination = dest;
    }

	override
	public void Execute(){
		if(owner.gameObject.transform.position == owner.GetComponent<Agent>().Home.position)
        {
            owner.GetComponent<Agent>().StateMachine.ChangeToGoDungeon() ;
        }
	}
	override
	public void Exit(){
		 
	}



}
