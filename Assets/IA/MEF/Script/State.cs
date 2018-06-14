using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State  {

	protected GameObject owner;

	public State(GameObject own){
		owner=own;
        Enter();
	}

	public virtual void Enter(){

	 }
	public virtual void Execute(){
		 
	 }
	 public virtual void Exit(){
	 }

	

}
