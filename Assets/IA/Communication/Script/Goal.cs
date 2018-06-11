using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Goal : IComparable<Goal>{

    public enum Objective_T { RELIC, KEY, TRAP, MONSTER };

    public static int global_objective_id = 0;

    [SerializeField] int id;
    [SerializeField] Objective_T type;
    [SerializeField] Transform location;
    [SerializeField] BaseEntity.Class_T concern;

    Agent owner;
    public Agent Owner { get { return owner; } set { owner = value; } }

    public Goal(Interactable obj, Agent own)
    {
        this.owner = own;
        this.Id = obj.ID;
        this.Type = obj.Type;
        this.Location = obj.MyTransform;
        this.Concern = obj.Concern;
        global_objective_id++;
    }

    public int Score(Goal goal, BaseEntity.Class_T my_class)
    {
        if (goal.Concern == my_class)
        {
            return 0;
        }
        if (goal.Concern == BaseEntity.Class_T.ALL)
        {
            return 1;
        }
        if (goal.Concern == BaseEntity.Class_T.NOBODY)
        {
            return 3;
        }
        return 2;
    }

    public int CompareTo(Goal other)
    {
        return CompareTo(other, Owner.entity.Class);
    }

    public int CompareTo(Goal other, BaseEntity.Class_T my_class)
    {
        return Score(this, my_class) - Score(other, my_class);
    }

    public override string ToString()
    {
        return Id.ToString() + " " + TypeToString(type) ;
        //return id.ToString() + " " + type.ToString() + " " + location.position.ToString() + " " + concern.ToString();
    }

    public static String TypeToString(Objective_T type )
    {
        switch (type)
        {
            case Goal.Objective_T.TRAP:
                return "TRAP";
            case Goal.Objective_T.MONSTER:
                return "MONSTER";
            case Goal.Objective_T.RELIC:
                return "RELIC";
            case Goal.Objective_T.KEY:
                return "KEY";
        }
        return "";
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public Objective_T Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public Transform Location
    {
        get
        {
            return location;
        }

        set
        {
            location = value;
        }
    }

    public BaseEntity.Class_T Concern
    {
        get
        {
            return concern;
        }

        set
        {
            concern = value;
        }
    }
}
