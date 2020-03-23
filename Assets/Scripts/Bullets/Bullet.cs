using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected int damage;
    private int _speed;

    public void Init(int speed)
    {
        _speed = speed;
    }

    private void Start()
    {
        StartCoroutine(Fly());
    }

    protected virtual IEnumerator Fly()
    {
        yield return null;

        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        
        StartCoroutine(Fly());
    }
}
