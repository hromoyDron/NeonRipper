using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBullet : Bullet
{
    [SerializeField] private float frequency = .1f;
    private List<IDamageable> victimBuffer = new List<IDamageable>();
    private WaitForSeconds frequencyTime;

    private void Start()
    {
        frequencyTime = new WaitForSeconds(frequency);

        StartCoroutine(Fly());
        StartCoroutine(MakeDamage());
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Enemy enemy = collider2D.GetComponent<Enemy>();
        if(enemy != null)
            victimBuffer.Add(enemy);  
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        Enemy enemy = collider2D.GetComponent<Enemy>();
        if(enemy != null)
            victimBuffer.Remove(enemy);
    }

    private IEnumerator MakeDamage()
    {
        yield return frequency;

        for(int i = 0; i < victimBuffer.Count; i++)
            victimBuffer[i].GetDamage(damage, null);

        StartCoroutine(MakeDamage());
    }
}
