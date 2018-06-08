using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BaseEntity {


    public Monster(int health, int damage, int energy, Inventory inventory) : base(health, damage, energy, inventory)
    {
        my_class = BaseEntity.Class_T.MONSTER;
    }

    public Monster(Inventory inventory) : base (inventory)
    {
        my_class = BaseEntity.Class_T.MONSTER;
    }

}
