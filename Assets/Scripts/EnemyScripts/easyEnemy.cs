using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class easyEnemy : MonoBehaviour
{
    public VisualEffect vfx;
    bool isAlive = true;

    // Start is called before the first frame update
    void Awake()
    {
        vfx = GetComponent<VisualEffect>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<enemyParent>().currentHealth == 0 && isAlive)
        {
            destroySelf();
        }
    }


    void destroySelf()
    {
        isAlive = false;
        vfx.SendEvent("OnDeath");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);

        GameObject.FindWithTag("GameController").GetComponent<spawnWaves>().decreaseEnemyCount();
        
    }
}
