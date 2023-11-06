using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemys : MonoBehaviour
{
    GameObject enemyContainer;
    GameObject spawnPointContainer;
    Transform[,] vectorCollection;
    string movementSet;
    public float speed;

    bool moveRight = true;
    float currentRelativePosition;
    public float movementBorder = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPointContainer = GameObject.FindGameObjectWithTag("GameController");
        vectorCollection = spawnPointContainer.GetComponent<SpawnEnemy>().getSpawningRows();
        currentRelativePosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementSet == "Horizontal")
        {
            if(moveRight)
            {
                enemyContainer.transform.position = new Vector3(enemyContainer.transform.position.x + speed, enemyContainer.transform.position.y, enemyContainer.transform.position.z);
                currentRelativePosition += speed;
            }
            else
            {
                enemyContainer.transform.position = new Vector3(enemyContainer.transform.position.x - speed, enemyContainer.transform.position.y, enemyContainer.transform.position.z);
                currentRelativePosition -= speed;
            }

            if(currentRelativePosition >= movementBorder)
            {
                moveRight = false;
            }
            else if(currentRelativePosition <= -movementBorder)
            {
                moveRight = true;
            }
            
        }
    }


    public void SetMovementInstructions(GameObject container, string movementInstruction)
    {
        enemyContainer = container;

        switch(movementInstruction)
        {
            case ("Horizontal"):
                movementSet = movementInstruction;
                break;
        }
    }

    public void clearMovementInstructions()
    {
        movementSet = "";
    }
}
