using System.Collections.Generic;
using UnityEngine;

// Class that stores the haptic device grabber positions to be used by the camera to rotate
public class HapticRotationQueue : MonoBehaviour
{
    private Vector3 prevPosition;
    public static Queue<Vector3> rotations;

    // Start is called before the first frame update
    void Start()
    {
        this.prevPosition = this.transform.position;
        rotations = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = this.transform.position;

        // Transform it into the Euler rotations
        float diffX = (newPosition.x - prevPosition.x) * 30f;
        float diffY = -1f * (newPosition.y - prevPosition.y) * 30f;
        float diffZ = (newPosition.z - prevPosition.z) * 30f;

        rotations.Enqueue(new Vector3(diffX, diffY, diffZ));
        this.prevPosition = newPosition;
    }
}
