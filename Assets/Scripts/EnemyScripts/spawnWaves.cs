using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWaves : MonoBehaviour
{
    [SerializeField]
    bool spawnCubeDev;

    bool waveAlive = false;

    int currentEnemys = 0;

    GameObject enemyContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCubeDev)
        {
            spawnCubeDev = false;
            enemyContainer = GetComponent<SpawnEnemy>().SpawnWaveHorizontal(50, 34, 0, 4, 1,"cube");
            GetComponent<moveEnemys>().SetMovementInstructions(enemyContainer, "Horizontal");
        }

        if(Input.GetKey(KeyCode.P) && !waveAlive)
        {
            waveAlive = true;
            enemyContainer = GetComponent<SpawnEnemy>().SpawnWaveHorizontal(50, 34, 0, 4, 1,"basicShip");
            GetComponent<moveEnemys>().SetMovementInstructions(enemyContainer, "Horizontal");
        }

        if(currentEnemys == 0 && enemyContainer != null)
        {
            waveAlive = false;
            Destroy(enemyContainer, 1f);
            GetComponent<moveEnemys>().clearMovementInstructions();
        }

    }

    public void increaseEnemyCount()
    {
        currentEnemys++;
    }

    public void decreaseEnemyCount()
    {
        currentEnemys--;
    }
}
