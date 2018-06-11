using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoDungeon : State
{

    public GoDungeon(GameObject own) : base(own)
    {

    }

    override
    public void Enter()
    {
        Debug.Log("En route pour le donjon");
        Vector3 dest = owner.GetComponent<Agent>().DungeonEntranceTP.position;
        owner.GetComponent<NavMeshAgent>().destination = dest;
    }

    override
    public void Execute()
    {
        Debug.Log("Arrivé au donjon");
        if (owner.gameObject.transform.position == owner.GetComponent<Agent>().DungeonEntrance.position)
        {
            owner.GetComponent<Agent>().StateMachine.ChangeState(); ;
        }
    }
    override
    public void Exit()
    {

    }



}
