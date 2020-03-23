using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    public static event EventController.ObjectStringHandler WeaponChanged;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _currentWeapon = 0;

    private int currentWeapon
    {
        get{ return _currentWeapon;}
        set
        { 
            if(value < 0)
                value = _weapons.Count - 1;
            if(value == _weapons.Count)
                value = 0;
            
            _currentWeapon = value;
        }
    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        GetComponentsInChildren<Weapon>(_weapons);

        for(int i = 1; i < _weapons.Count; i++)
            _weapons[i].gameObject.SetActive(false);

        if(WeaponChanged != null)
            WeaponChanged(this, GetCurrentWeaponName());
    }

    public void Attack()
    {
        if(_weapons.Count > 0)
            _weapons[currentWeapon].Attack();
    }

    public void ChangeWeapon(int number) 
    {
        if(_weapons.Count > 0)
        {
            _weapons[currentWeapon].gameObject.SetActive(false);

            currentWeapon += number;

            _weapons[currentWeapon].gameObject.SetActive(true);

            if(WeaponChanged != null)
                WeaponChanged(this, GetCurrentWeaponName());

        }
    }

    private string GetCurrentWeaponName()
    {
        if(_weapons.Count > 0)
            return _weapons[currentWeapon].name;
        else 
            return "";
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space))
            Attack();

        if(Input.GetKeyUp(KeyCode.Q))
            ChangeWeapon( -1);
        if(Input.GetKeyUp(KeyCode.E))
            ChangeWeapon( +1);
    }
}
