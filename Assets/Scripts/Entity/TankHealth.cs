using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour, IDamageable
{
    public static event EventController.ObjectHandler HealthChanged;

    private float _currentHealth;
    [SerializeField] private float _armor;
    [SerializeField] private float _health;

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

            if(HealthChanged != null)
                HealthChanged(this);
        }
    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        currentHealth = health;  
    }

    public void GetDamage(int damage, IDamageable attacker)
    {
        currentHealth -= damage * (1 - _armor);
    }
}
