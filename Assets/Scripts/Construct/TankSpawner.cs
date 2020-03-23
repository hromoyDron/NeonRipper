using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public GameObject Create()
    {
        Vector2 pos = Vector2.zero;
        GameObject tankGO = (GameObject) Instantiate(Resources.Load("tank"));
        tankGO.transform.position = pos;

        return tankGO;
    }
}
