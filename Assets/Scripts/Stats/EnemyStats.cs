
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
   public override void Die()
    {
        base.Die();

        //Add death animation or ragdoll effect

        Destroy(gameObject);
        //Add loot
    }
}
