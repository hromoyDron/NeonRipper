using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static EventController.ObjectHandler RetryClicked;
    public static EventController.ObjectHandler StartClicked;

    public StartWindow startWindow;
    public PlayWindow playWindow;
    public LoseWindow loseWindow;

    private void OnEnable()
    {
        TankHealth.HealthChanged += TankHealthChangedListener;
        TankWeapon.WeaponChanged += TankWeaponChangedListener;
    }

    private void OnDisable()
    {
        TankHealth.HealthChanged -= TankHealthChangedListener;
        TankWeapon.WeaponChanged -= TankWeaponChangedListener;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        loseWindow.Init(OnRetryClick);
        loseWindow.gameObject.SetActive(false);

        startWindow.Init(OnStartClick);
        startWindow.gameObject.SetActive(true);

        playWindow.Init();
        playWindow.gameObject.SetActive(false);
    }

    private void TankHealthChangedListener(Object obj)
    {
        playWindow.RefreshHealth(obj);

        IDamageable tank = obj as IDamageable;
        if(tank.currentHealth <= 0)
        {
            playWindow.gameObject.SetActive(false);
            loseWindow.gameObject.SetActive(true);
        }
    }

    private void TankWeaponChangedListener(Object obj, string weaponName)
    {
        playWindow.ChangeWeapon(weaponName);
    }

    private void OnStartClick()
    {
        startWindow.gameObject.SetActive(false);
        playWindow.gameObject.SetActive(true);

        if(StartClicked != null)
            StartClicked(this);
    }

    private void OnRetryClick()
    {
        loseWindow.gameObject.SetActive(false);
        playWindow.gameObject.SetActive(true);

        if(RetryClicked != null)
            RetryClicked(this);
    }
}
