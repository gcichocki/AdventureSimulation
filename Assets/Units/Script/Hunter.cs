using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : BaseEntity
{


    public Hunter(int health, int damage, int energy, Inventory inventory) : base(health, damage, energy, inventory)
    {

    }

    public Hunter(Inventory inventory) : base(inventory)
    {

    }

}