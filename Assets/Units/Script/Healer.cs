using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : BaseEntity
{


    public Healer(int health, int damage, int energy, Inventory inventory) : base(health, damage, energy, inventory)
    {
        my_class = BaseEntity.Class_T.HEALER;
    }

    public Healer(Inventory inventory) : base(inventory)
    {
        my_class = BaseEntity.Class_T.HEALER;
    }

}