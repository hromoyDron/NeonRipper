using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : Bullet
{
    [SerializeField] private float explosionRadius;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, explosionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable victim = colliders[i].GetComponent<IDamageable>();

            if(victim == null)
                continue;

            victim.GetDamage(damage, null);

            Destroy(gameObject);
        }
    }
}
