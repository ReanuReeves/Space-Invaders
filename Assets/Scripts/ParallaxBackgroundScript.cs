using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxBackgroundScript : MonoBehaviour
{
    public float speed;
    public Transform teleportPoint;
    public Transform teleportThreshhold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        if(transform.position.y <= teleportThreshhold.position.y)
        {
            transform.position = new Vector3(transform.position.x, teleportPoint.position.y, transform.position.z);
        }
    }
}
