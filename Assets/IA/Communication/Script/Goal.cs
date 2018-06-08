using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal  {

    public enum Objective_T { RELIC, KEY, TRAP, MONSTER };

    public static int global_objective_id = 0;

    [SerializeField] int id;
    [SerializeField] Objective_T type;
    [SerializeField] Transform location;
    [SerializeField] BaseEntity.Class_T concern;

    public Goal(int id, Objective_T type, Transform location, BaseEntity.Class_T concern)
    {
        this.id = global_objective_id;
        this.type = type;
        this.location = location;
        this.concern = concern;
        global_objective_id++;
    }
}
