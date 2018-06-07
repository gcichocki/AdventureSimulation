using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : BaseEntity
{


    public Fighter(int health, int damage, int energy, Inventory inventory) : base(health, damage, energy, inventory)
    {

    }

    public Fighter(Inventory inventory) : base(inventory)
    {

    }

}