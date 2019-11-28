using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bodyPosition = BodyPosition.bodyPosition;
        Vector3 grabberPosition = new Vector3(bodyPosition.x, bodyPosition.y + 2.5f, bodyPosition.z);

        this.gameObject.transform.position = grabberPosition;
    }
}
