using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public VisualEffect vfx;
    bool isAlive = true;

    public int baseDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAlive)
        {
            transform.position += new Vector3(0, bulletSpeed, 0);            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            isAlive = false;
            GetComponent<MeshRenderer>().enabled = false;
            vfx.SendEvent("OnHit");
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerShooting>().setBulletFalse();
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 0.8f);

        }
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemyParent>().TakeDamage(baseDamage);
        }
    }
}
