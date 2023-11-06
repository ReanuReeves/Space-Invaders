using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> rowContainers;

    public List<GameObject> enemyTypes;
    
    int rows;
    Transform[,] spawningRows;
    void Start()
    {
        

        rows = rowContainers.Count;

        spawningRows = new Transform[rows,2];

        generateHorizontalRows();
        
    }

    void generateHorizontalRows()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < rowContainers[i].transform.childCount; j++)
            {
                // Debug.Log(i + "     " + j + "     " + rowContainers[i].transform.GetChild(j));
                spawningRows[i,j] = rowContainers[i].transform.GetChild(j).transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnWaveHorizontal(int pInterval, int pOffRowInterval, int pStartRow, int pEndRow, int pStep, string pEnemyType)
    {
        GameObject enemyContainer = new GameObject("EnemyContainer");
        int defaultInterval = pInterval;

        //spawns 2 enemys per row
        for(int i = pStartRow; i < pEndRow; i += pStep)
        {
            GameObject rowContainer = new GameObject("rowContainer" + i);
            rowContainer.transform.parent = enemyContainer.transform;
            float lerpValue = 0f;
            // Debug.Log("current index:    "+ i);

            if(i%2 == 1 && pOffRowInterval != 0)
            {
                pInterval = pOffRowInterval;
            }
            else
            {
                pInterval = defaultInterval;
            }

            for(int j = 0; j<100; j++)
            {
                lerpValue += 0.01f;
                // Debug.Log("Current inner index: " + j + "    Current division:" + j%pInterval);
                if(j%pInterval == 0 && j == 0 && pOffRowInterval == 0 || j%pInterval == 0 && j > 0)
                {
                    Debug.Log(spawningRows[i,1].transform.position + "    " + spawningRows[i,0].transform.position);
                    Debug.Log(i + "    " + j);
                    Vector3 spawnPoint = Vector3.Lerp(spawningRows[i,1].transform.position, spawningRows[i,0].transform.position, lerpValue);
                    InitializeEnemy(pEnemyType, spawnPoint).transform.parent = rowContainer.transform;
                    gameObject.GetComponent<spawnWaves>().increaseEnemyCount();
                }
            }
        }

        return enemyContainer;
    }

    GameObject InitializeEnemy(string pEnemyType, Vector3 pSpawnPoint)
    {
        switch(pEnemyType)
        {
            case "cube":
                // Debug.Log("SpawnPosOfCube: " + pSpawnPoint);
                return Instantiate(enemyTypes[0], pSpawnPoint, transform.rotation);
            case "basicShip":
                var ship = Instantiate(enemyTypes[1]);
                ship.transform.position = pSpawnPoint;
                return ship;
            default:
                return Instantiate(enemyTypes[0], pSpawnPoint, transform.rotation);
        }
    }

    public Transform[,] getSpawningRows()
    {
        return spawningRows;
    }
}
