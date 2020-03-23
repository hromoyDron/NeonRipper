using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public static event EventController.ObjectHandler EnemyDead;

    private float _currentHealth;
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;
    [SerializeField] public float _health;
    [SerializeField] public float _armor;


    private Transform _victimTransform;
    private Rigidbody2D _rigidbody2D;

    public float health { get { return _health; }}

    public float currentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            if(value < 0)
                value = 0;

            _currentHealth = value;
        }
    }


    public void GetDamage(int damage, IDamageable attacker)
    {
        currentHealth -= damage * (1 - _armor);

        if(_currentHealth <= 0)
        {
            EnemyDead(this);
            Destroy(this.gameObject);
        }   
    }

    public void Init(Transform victimTransform)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _victimTransform = victimTransform;

        currentHealth = health;
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();          
    }

    private void Move()
    {
        Vector2 move = transform.up * _speed * Time.deltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + move); 
    }

    private void Rotate()
    {
        Vector2 position = _victimTransform.position;

        Vector2 targetDir = position - (Vector2)transform.position;
        Vector2 localTarget = transform.InverseTransformPoint(position);
     
        float angle = Mathf.Atan2(localTarget.x, localTarget.y) * Mathf.Rad2Deg;
        _rigidbody2D.MoveRotation(_rigidbody2D.rotation - angle);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        IDamageable victim = collider2D.GetComponent<TankHealth>();

        if(victim != null)
        {
            victim.GetDamage(_damage, this);
            
            EnemyDead(this);
            Destroy(gameObject);
        }
    }
}
