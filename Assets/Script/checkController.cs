using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkController : MonoBehaviour
{
    //definir una matriz y la llenamos
    public static checkController instance;
    public CheckPoint[] checkPoints;
    //para guardar las coordenadas pasadas
    public Vector3 spawnPoint;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();
        spawnPoint = Personaje.instance.transform.position;
    }


    // Update is called once per frame
    public void DeactivateCheckPont()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint) 
    {

        spawnPoint = newSpawnPoint;
    }

}
