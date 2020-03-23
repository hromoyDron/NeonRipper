using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera cam;
    private FieldConstructor field;

    private void Start()
    {
        field = GetComponent<FieldConstructor>();
        cam = Camera.main;
    }

    public Enemy CreateEnemy(Object enemyObj, Transform victimTransform)
    {
        Vector2 pos = GetPosition();
        GameObject enemyGO = (GameObject) Instantiate(enemyObj);
        enemyGO.transform.position = pos;
        
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Init(victimTransform);

        return enemy;
    }

    private Vector2 GetPosition()
    {
        List<Vector2> directions = new List<Vector2>();

        directions.Add(Vector2.left);
        directions.Add(Vector2.right);
        directions.Add(Vector2.up);
        directions.Add(Vector2.down);

        Vector2 worldPosition;
        
        worldPosition = cam.ViewportToWorldPoint(Vector2.zero);
        
        if(worldPosition.x < -field.sizeX/2)
            directions.Remove(Vector2.left);
        if(worldPosition.y < -field.sizeY/2)
            directions.Remove(Vector2.down);

        worldPosition = cam.ViewportToWorldPoint(Vector2.one);
        
        if(worldPosition.x > field.sizeX/2)
            directions.Remove(Vector2.right);
        if(worldPosition.y > field.sizeY/2)
            directions.Remove(Vector2.up);

        if(directions.Count > 0)
        {
            Vector2 direction = directions[Random.Range(0, directions.Count)];

            float x = (field.sizeX * direction.x)/2 + Random.Range(-field.sizeX/2, field.sizeX/2) * Mathf.Abs(direction.y);
            float y = (field.sizeY * direction.y)/2 + Random.Range(-field.sizeY/2, field.sizeY/2) * Mathf.Abs(direction.x); 

            return new Vector2(x, y);
        }
        else
        {
            return Vector2.zero;
        }
    }
}
