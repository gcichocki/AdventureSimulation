using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseEntity {

    protected Inventory inventory;

    [Header("Attributes")]
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected int energy;
    

    [Header("Attack Sensor")]
    [Tooltip("Settings for the attack sensor of the entity")]
    [SerializeField]
    protected Sensor attackRange;

    public int Health { get { return health; } set { health = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public int Energy { get { return energy; } set { energy = value; } }
    public Inventory Inventory { get { return inventory; } set { inventory = value; } }

    public BaseEntity(int health, int damage, int energy, Inventory inventory)
    {
        this.Health = health;
        this.Damage = damage;
        this.Inventory = inventory;
        this.Energy = energy;
    }

    public BaseEntity(Inventory inventory)
    {
        this.Inventory = inventory;
    }


}
