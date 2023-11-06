using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour
{
    bool isMoving = false;
    float border = 5;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < border)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+speed, transform.position.z);
        }
    }



    
}
