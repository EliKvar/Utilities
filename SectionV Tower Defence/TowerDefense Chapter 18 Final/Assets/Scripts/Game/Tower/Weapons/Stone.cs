using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : FollowProjectile
{
    public float damage;

    protected override void OnHitEnemy()
    {
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }
}
