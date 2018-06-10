using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    [SerializeField] int id;
    [SerializeField] Transform myTransform;
    [SerializeField] Goal.Objective_T type;
    [SerializeField] BaseEntity.Class_T concern;

    public Transform MyTransform { get { return myTransform; } set { myTransform = value; } }
    public BaseEntity.Class_T Concern { get { return concern; } set { concern = value; } }
    public Goal.Objective_T Type { get { return type; } set { type = value; } }
    public int ID { get { return id; } set { id = value; } }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}