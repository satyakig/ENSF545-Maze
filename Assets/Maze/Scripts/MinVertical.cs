using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that forces a game object to not go below a specifc Y value
public class MinVertical : MonoBehaviour
{
    const float MIN_Y = -5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.gameObject.transform.position;
        if (currentPosition.y <= MIN_Y)
        {
            //Debug.Log("gameObject too low, move up from: " + currentPosition.y);
            this.gameObject.transform.position = new Vector3(currentPosition.x, 0.1f, currentPosition.z);
        }
    }
}
