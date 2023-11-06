using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyParent : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int pDamage)
    {
        currentHealth -= pDamage;
    }
}
