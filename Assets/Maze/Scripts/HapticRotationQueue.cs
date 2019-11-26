using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that stores the haptic device grabber positions to be used by the camera to rotate
public class HapticRotationQueue : MonoBehaviour
{
    private Vector3 PrevPosition;
    public static Queue<Vector3> rotations;

    // Start is called before the first frame update
    void Start()
    {
        PrevPosition = transform.position;

        rotations = new Queue<Vector3>();

        // Add two empty rotations
        rotations.Enqueue(new Vector3(0, 0, 0));
        rotations.Enqueue(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NewPosition = transform.position;

        // Transform it into the Euler rotations
        float diffX = NewPosition.x - PrevPosition.x;
        float diffY = -1f * (NewPosition.y - PrevPosition.y);
        float diffZ = NewPosition.z - PrevPosition.z;

        rotations.Enqueue(new Vector3(diffY, diffX, diffZ));
        PrevPosition = NewPosition;
    }
}
