using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldConstructor : MonoBehaviour
{
    public int sizeX{ get{return _sizeX;}}
    public int sizeY{ get{return _sizeY;}}
    public GameObject wall;

    [SerializeField] private int thickness;
    [SerializeField] private int _sizeX;
    [SerializeField] private int _sizeY;

    private void Start()
    {
        CreateField();
    }

    public void CreateField()
    {

        Vector2 upperPosition = new Vector2( 0, sizeY/2 + thickness/2);
        Vector2 upperScale = new Vector2( sizeX + thickness * 2, thickness); 
        CreateWall( upperPosition, upperScale);

        Vector2 bottomPosition = new Vector2( 0, -sizeY/2 - thickness/2);
        Vector2 bottomScale = new Vector2( sizeX + thickness * 2, thickness); 
        CreateWall( bottomPosition, bottomScale);

        Vector2 leftPosition = new Vector2( -sizeX/2 - thickness/2, 0);
        Vector2 leftScale = new Vector2( thickness, sizeY + thickness * 2); 
        CreateWall( leftPosition, leftScale);

        Vector2 rightPosition = new Vector2( sizeX/2 + thickness/2, 0);
        Vector2 rightScale = new Vector2( thickness, sizeY + thickness * 2); 
        CreateWall( rightPosition, rightScale);
    }

    private void CreateWall(Vector2 position, Vector2 scale)
    {
        GameObject w = (GameObject) Instantiate( wall);

        w.transform.localPosition = position;
        w.transform.localScale = scale * 100;
    }
}
