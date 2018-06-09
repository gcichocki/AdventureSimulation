using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    [SerializeField] int id;
    [SerializeField] BaseEntity.Class_T concern;

    public BaseEntity.Class_T Concern { get { return concern; } set { concern = value; } }
    public int ID { get { return id; } set { id = value; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
