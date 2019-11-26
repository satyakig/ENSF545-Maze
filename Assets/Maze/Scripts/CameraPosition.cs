using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

// Class that tracks the main camera position
public class CameraPosition : MonoBehaviour
{
    public GameObject mainCamera;

    private const float START_MAZE_Z_POS = -60f;
    private const float END_MAZE_Z_POS = 60f;

    public bool pastStartPoint = false;
    public bool pastEndPoint = false;

    public Stopwatch stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        UnityEngine.Debug.Log("Main Camera: " + Camera.main.name);
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckCameraPosition();

        // Rotate the camera based on the haptic device position
        Queue<Vector3> rotations = HapticRotationQueue.rotations;
        if (rotations != null)
        {
            int count = rotations.Count;
            if (count > 0)
            {
                Vector3 rotation = rotations.Dequeue();
                this.mainCamera.transform.Rotate(rotation.x, rotation.y, 0f);
            }
        }
    }

    // Check whether the camera is past the start or end points
    private void CheckCameraPosition()
    {
        Vector3 cameraPosition = this.mainCamera.transform.position;

        // Check the camera position to determine whether the player has started the maze or not
        bool start;
        if (cameraPosition.z >= START_MAZE_Z_POS)
        {
            start = true;
        }
        else
        {
            start = false;
        }

        bool end;
        if (cameraPosition.z >= END_MAZE_Z_POS)
        {
            end = true;
        }
        else
        {
            end = false;
        }

        // Start stopwatch if the camera is past the start point
        if (!this.pastStartPoint && start)
        {
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
            UnityEngine.Debug.Log("Starting stopwatch");
        }

        // Stop stopwatch if camera is past the end point
        if (!this.pastEndPoint && end)
        {
            this.stopwatch.Stop();
            UnityEngine.Debug.Log("Ending stopwatch");


            TimeSpan ts = this.stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}m:{1:00}s:{2:00}ms",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            UnityEngine.Debug.Log("Ending stopwatch");
            UnityEngine.Debug.Log("Run Time: " + elapsedTime);
            UnityEngine.Debug.Log("Run Time: " + this.stopwatch.ElapsedMilliseconds + "ms");
        }

        this.pastStartPoint = start;
        this.pastEndPoint = end;
    }
}
