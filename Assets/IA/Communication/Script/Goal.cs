﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : IComparable<Goal>{

    public enum Objective_T { RELIC, KEY, TRAP, MONSTER };

    public static int global_objective_id = 0;

    [SerializeField] int id;
    [SerializeField] Objective_T type;
    [SerializeField] Transform location;
    [SerializeField] BaseEntity.Class_T concern;

   

    public Goal(Objective_T type, Transform location, BaseEntity.Class_T concern)
    {
        this.Id = global_objective_id;
        this.Type = type;
        this.Location = location;
        this.Concern = concern;
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
        return 2;
    }

    public int CompareTo(Goal other)
    {
        return CompareTo(other, BaseEntity.Class_T.FIGHTER);
    }

    public int CompareTo(Goal other, BaseEntity.Class_T my_class)
    {
        return Score(this, my_class) - Score(other, my_class);
    }

    public override string ToString()
    {
        return Id.ToString();
        //return id.ToString() + " " + type.ToString() + " " + location.position.ToString() + " " + concern.ToString();
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