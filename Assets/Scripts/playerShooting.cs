using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;


public class playerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    [SerializeField]
    bool hasBullet = false;

    public VisualEffect vfx;

    public GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar");
            if(!hasBullet)
            {
                vfx.SendEvent("Shoot");
                audio.GetComponent<playerAudio>().playShootingSound();
                hasBullet = true;
                Instantiate(bulletPrefab, bulletSpawnPoint, false);
            }
        }
    }

    public void setBulletFalse()
    {
        hasBullet = false;
    }
}
