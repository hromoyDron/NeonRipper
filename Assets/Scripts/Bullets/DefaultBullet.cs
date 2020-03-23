using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        IDamageable victim = collider2D.GetComponent<IDamageable>();

        if(victim != null)
            victim.GetDamage(damage, null);

        Destroy(gameObject);
    }
}
