using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that forces a game object to not go below a specifc Y value
public class MinVertical : MonoBehaviour
{
    GameObject Object;
    const float MIN_Y = -1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Object = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CurrentPositon = Object.transform.position;
        if (CurrentPositon.y <= MIN_Y)
        {
            Debug.Log("Object too low, move up from: " + CurrentPositon.y);
            Object.transform.position = new Vector3(CurrentPositon.x, 0.1f, CurrentPositon.z);
        }
    }
}
