using UnityEngine;
using System.Diagnostics;
using System;

// Class that tracks the main camera position
public class CameraTracker : MonoBehaviour
{
    public GameObject mainCamera;

    private const float START_MAZE_Z_POS = -60f;
    private const float END_MAZE_Z_POS = 61f;
    public Stopwatch stopwatch;

    private readonly float MAX_TILT = 6f;
    private readonly float ROTATE_AMT = 0.25f;
    private bool shouldTilt = false;
    private float currentRotation = 0f;
    private bool isPositiveTilt = true;

    private string axis = "X";
    private readonly string xAxis = "X";

    private bool pastStart = false;
    private bool pastEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.stopwatch = new Stopwatch();
        UnityEngine.Debug.Log("Main Camera: " + Camera.main.name);

        InvokeRepeating("ShouldStartTilt", 0f, 1f);
        InvokeRepeating("ShouldStopTilt", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckCameraPosition();

        if (this.shouldTilt)
        {
            this.TiltCamera();
        } else
        {
            this.ResetTilt();
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
        if (start && !this.pastStart)
        {
            this.stopwatch.Start();
            UnityEngine.Debug.Log("Starting stopwatch");
            this.pastStart = start;
        }

        // Stop stopwatch if camera is past the end point
        if (end && !this.pastEnd)
        {
            this.stopwatch.Stop();
            UnityEngine.Debug.Log("Ending stopwatch");

            TimeSpan ts = this.stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}m:{1:00}s:{2:00}ms",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            UnityEngine.Debug.Log("Ending stopwatch");
            UnityEngine.Debug.Log("Run Time: " + elapsedTime);
            UnityEngine.Debug.Log("Run Time: " + this.stopwatch.ElapsedMilliseconds + "ms");
            this.pastEnd = end;
        }
    }

    private void ShouldStartTilt()
    {
        if (new System.Random().Next(2) == 0)
        {
            if (!this.shouldTilt)
            {
                if (this.axis == this.xAxis)
                {
                    this.axis = "Z";
                } else
                {
                    this.axis = this.xAxis;
                }
            }
            this.shouldTilt = true;
        }
    }

    private void ShouldStopTilt()
    {
        if (new System.Random().Next(2) == 1)
        {
            this.shouldTilt = false;
        }
    }

    private void TiltCamera()
    {
        float rotate = ROTATE_AMT;
        if (Math.Abs(this.currentRotation) > MAX_TILT)
        {
            this.isPositiveTilt = !this.isPositiveTilt;
        }

        if (!this.isPositiveTilt)
        {
            rotate *= -1;
        }

        this.currentRotation += rotate;

        if (this.axis == this.xAxis)
        {
            this.mainCamera.transform.Rotate(rotate, 0f, 0f);
        } else
        {
            this.mainCamera.transform.Rotate(0f, 0f, rotate);
        }
        
    }

    private void ResetTilt()
    {
        if (Math.Abs(this.currentRotation) > 0)
        {
            float resetAngle = -1f * this.currentRotation;
            if (this.axis == this.xAxis)
            {
                this.mainCamera.transform.Rotate(resetAngle, 0f, 0f);
                this.currentRotation = 0f;
            }
            else
            {
                this.mainCamera.transform.Rotate(0f, 0f, resetAngle);
                this.currentRotation = 0f;
            }
            
        }
    }
}
