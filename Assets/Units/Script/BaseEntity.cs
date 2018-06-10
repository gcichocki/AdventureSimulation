using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BaseEntity {

    public enum Class_T { FIGHTER, HEALER, HUNTER, ALL, MONSTER };

    protected Inventory inventory;

    [Header("Attributes")]
    [SerializeField] protected int health = 100;
    [SerializeField] protected int damage = 20;
    [SerializeField] protected int energy = 100;
    [SerializeField] protected Class_T my_class;


    [Tooltip("Settings for the attack sensor of the entity")]
    [SerializeField]
    protected Sensor attackRange;
    public Sensor AttackRange { get { return attackRange; } set { attackRange = value; } }

    public int Health { get { return health; } set { health = value; } }
    public Class_T Class  { get { return my_class; } set { my_class = value; } }
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

    public bool NeedHeal()
    {
        return Health < 50;
    }
}
