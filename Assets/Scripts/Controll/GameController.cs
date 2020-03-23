using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TankSpawner tankSpawner;
    public EnemySpawner enemySpawner;
    public CameraFollowMovement cameraFollowMovement;

    private List<Enemy> enemyPool = new List<Enemy>();
    private Object[] enemyPrefabs;
    private GameObject tankGO;

    enum GameState
    {
        Play,
        Pause    
    }

    private GameState gameState;

    private void OnEnable()
    {
        Enemy.EnemyDead += OnEnemyDeathListener;

        UIController.StartClicked += StartClickLisner;
        UIController.RetryClicked += RetryClickLisner;

        TankHealth.HealthChanged += TankHealthChangedListener;
    }

    private void OnDisable()
    {
        Enemy.EnemyDead -= OnEnemyDeathListener;

        UIController.StartClicked -= StartClickLisner;
        UIController.RetryClicked -= RetryClickLisner;

        TankHealth.HealthChanged += TankHealthChangedListener;
    }

    private void StartClickLisner(object obj)
    {
        StartPlay();
    }

    private void RetryClickLisner(object obj)
    {
        Retry();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        gameState = GameState.Pause;
        enemyPrefabs = Resources.LoadAll("Enemy");
    }

    private void StartPlay()
    {
        tankGO = tankSpawner.Create();   
        cameraFollowMovement.SetFollower(tankGO.transform);
        gameState = GameState.Play;
    }

    private void Retry()
    {
        ClearScene();
        StartPlay();
    }

    private void ClearScene()
    {
        Destroy(tankGO);

        while(enemyPool.Count > 0)
        {
           Destroy(enemyPool[0].gameObject);
           enemyPool.RemoveAt(0);
        }
    }

    private void Update()
    {
        if(enemyPool.Count <= 10 && gameState == GameState.Play)
        {
            Object enemyObj = enemyPrefabs[ Random.Range(0, enemyPrefabs.Length)];
            Enemy enemy = enemySpawner.CreateEnemy(enemyObj, tankGO.transform);
            enemyPool.Add(enemy);
        }
    }

    private void TankHealthChangedListener(Object obj)
    {
        IDamageable tank = obj as IDamageable;

        if(tank.currentHealth <= 0)
            gameState = GameState.Pause;
    }

    private void OnEnemyDeathListener(object obj)
    {
        Enemy enemy = obj as Enemy;
        enemyPool.Remove(enemy);
    }
}
