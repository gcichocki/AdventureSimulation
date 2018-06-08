using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : BaseEntity
{


    public Fighter(int health, int damage, int energy, Inventory inventory) : base(health, damage, energy, inventory)
    {
        my_class = BaseEntity.Class_T.FIGHTER;
    }

    public Fighter(Inventory inventory) : base(inventory)
    {
        my_class = BaseEntity.Class_T.FIGHTER;
    }

}