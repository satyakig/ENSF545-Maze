using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

// Class that tracks the main camera position
public class CameraPosition : MonoBehaviour
{
    Camera MainCamera;
    public static Vector3 MainCameraPosition;

    private const float StartZPoistion = -60f;
    private const float EndZPosition = -50f;

    public static bool PastStart = false;
    public static bool PastEnd = false;

    public static Stopwatch stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        UnityEngine.Debug.Log("Main Camera: " + MainCamera.name);
    }

    // Update is called once per frame
    void Update()
    {
        MainCameraPosition = MainCamera.gameObject.transform.position;

        bool start;
        if (MainCameraPosition.z >= StartZPoistion)
        {
            start = true;
        }
        else
        {
            start = false;
        }

        bool end;
        if (MainCameraPosition.z >= EndZPosition)
        {
            end = true;
        }
        else
        {
            end = false;
        }

        if (!PastStart && start)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            UnityEngine.Debug.Log("Starting stopwatch");
        }


        if (!PastEnd && end)
        {
            stopwatch.Stop();
            UnityEngine.Debug.Log("Ending stopwatch");


            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}m {1:00}s {2:00}ms",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            UnityEngine.Debug.Log("Ending stopwatch");
            UnityEngine.Debug.Log("Run Time: " + elapsedTime);
            UnityEngine.Debug.Log("Run Time: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        PastStart = start;
        PastEnd = end;
    }
}
