using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private int bulletSpeed;
    [SerializeField] private string bulletName;

    private float timer;
    private List<Transform> bulletSpawnPoints = new List<Transform>();

    private void Start()
    {
        timer -= cooldown;

        for(int i = 0; i < transform.childCount; i++)
        {
            bulletSpawnPoints.Add(transform.GetChild(i));
        }
    }

    public void Attack()
    {
        if(Time.time - timer > cooldown)
        {
            MakeShot();
        }
    }

    protected void MakeShot()
    {
        for(int i = 0; i < bulletSpawnPoints.Count; i++)
            CreateBullet( bulletSpawnPoints[i], bulletName);  
    }

    protected void CreateBullet(Transform spawnPoint, string bulletName)
    {
        timer = Time.time;

        GameObject bulletGO = (GameObject) Instantiate(Resources.Load("Bullets/" + bulletName));

        bulletGO.transform.position = spawnPoint.position;
        bulletGO.transform.rotation = spawnPoint.rotation;
            
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.Init(bulletSpeed);
    }
}
