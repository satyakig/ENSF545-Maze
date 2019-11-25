using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

// Class that tilts a game object along an axis
public class Tilt : MonoBehaviour
{
    private readonly double MAX_TILT = 5; // degrees
    private readonly float ROTATE_AMT = 0.25f; // degrees
    private bool ShouldTilt = false;
    private volatile float CurrentRotation = 0f;
    private volatile bool PosTilt = true;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckTiltInput", 0f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        this.Rotate();
    }

    // Toggle tilt on/off on key press T
    private void CheckTiltInput()
    {
        if (Input.GetKey(KeyCode.T))
        {
            if (this.ShouldTilt)
            {
                transform.Rotate(0, 0, -1 * this.CurrentRotation);
            }


            this.ShouldTilt = !this.ShouldTilt;
            Debug.Log("Tilt: " + this.ShouldTilt);
        }
    }

    private void Rotate()
    {
        if (this.ShouldTilt)
        {
            float rotate = ROTATE_AMT;

            if (Math.Abs(this.CurrentRotation) > MAX_TILT)
            {
                this.PosTilt = !this.PosTilt;
            }

            if (!this.PosTilt)
            {
                rotate *= -1;
            }

            this.CurrentRotation += rotate;
            transform.Rotate(0, 0, rotate);
        }
    }
}
