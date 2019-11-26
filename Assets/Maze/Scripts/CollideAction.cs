using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that checks if an object is colliding
public class CollideAction : MonoBehaviour
{
    public static bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name != "Floor")
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.name != "Floor")
        {
            isColliding = false;
        }
    }
}
