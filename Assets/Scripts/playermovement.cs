using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Unity.VisualScripting;

public class playermovement : MonoBehaviour
{
    float positionX;
    float velocity;
    public float acceleration;
    [Range(0.01f, 1f)]
    public float drag;
    public float movementRange;
    bool canTP = true;
    public VisualEffect vfx;
    bool hasBooster = false;
    public GameObject audio;


    // Start is called before the first frame update
    void Start()
    {
        positionX = 0;
        vfx = GetComponent<VisualEffect>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.P))
        {
            vfx.SendEvent("StartBooster");
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity = velocity - acceleration;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity = velocity + acceleration;
        }

        velocity *= drag;
        positionX += velocity;

        if (positionX > movementRange && canTP)
        {
            positionX = -movementRange;
            StartCoroutine(sideTPCooldown());
        }
        else if(positionX > movementRange)
        {
            positionX = movementRange;
        }

        if (positionX < -movementRange && canTP)
        {
            positionX = movementRange;
            StartCoroutine(sideTPCooldown());
        }
        else if(positionX < -movementRange)
        {
            positionX = -movementRange;
        }

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
    }


    IEnumerator sideTPCooldown()
    {
        audio.GetComponent<playerAudio>().playTeleportingSound();
        vfx.SendEvent("OnTP");
        canTP = false;
        yield return new WaitForSeconds(1);
        canTP = true;
    }
}