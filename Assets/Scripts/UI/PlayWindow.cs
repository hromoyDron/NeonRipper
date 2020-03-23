using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWindow : MonoBehaviour
{
    public Transform weaponsHolder;
    public TMPro.TextMeshProUGUI tankHealth;

    private Transform currentWeapon;

    public void Init()
    {
        for(int i = 0; i < weaponsHolder.childCount; i++)
            if(currentWeapon != weaponsHolder.GetChild(i))
                weaponsHolder.GetChild(i).gameObject.SetActive(false);
    }

    public void ChangeWeapon(string weaponName)
    {
        if(currentWeapon != null)
                currentWeapon.gameObject.SetActive(false);

        currentWeapon = weaponsHolder.Find(weaponName);

        if(currentWeapon != null)
            currentWeapon.gameObject.SetActive(true);
    }

    public void RefreshHealth(object obj)
    {
        IDamageable tank = obj as IDamageable;
        tankHealth.text = string.Format("{0}/{1}", (int) tank.currentHealth, (int) tank.health);
    }
}
