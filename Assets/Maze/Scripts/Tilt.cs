using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

// Class that tilts a game object along an axis
public class Tilt : MonoBehaviour
{
    private readonly double MAX_TILT = 10; // degrees
    private readonly float ROTATE_AMT = 0.25f; // degrees

    private string tiltAxis;
    private float currentRotation = 0f;
    private bool isPositiveTilt = true;
    private bool shouldTilt;

    // Start is called before the first frame update
    void Start()
    {
        this.tiltAxis = BodyPosition.Z;
        this.shouldTilt = false;
        InvokeRepeating("CheckTiltInput", 0f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.shouldTilt)
        {
            this.TiltObject();
        }
        else
        {
            this.ResetTilt();
        }
    }

    private void TiltObject()
    {
        //string newTiltAxis = BodyPosition.GetTiltAxis();

        //if (newTiltAxis != this.tiltAxis)
        //{
        //    this.ResetTilt();
        //}

        //this.tiltAxis = newTiltAxis;

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
        if (this.tiltAxis == BodyPosition.X)
        {
            this.transform.Rotate(rotate, 0f, 0f);
        }
        else if (this.tiltAxis == BodyPosition.Y)
        {
            this.transform.Rotate(0f, rotate, 0f);
        }
        else if (this.tiltAxis == BodyPosition.Z)
        {
            this.transform.Rotate(0f, 0f, rotate);
        }
    }

    private void ResetTilt()
    {
        if (Math.Abs(this.currentRotation) > 0)
        {
            if (this.tiltAxis == BodyPosition.X)
            {
                this.transform.Rotate(-1f * this.currentRotation, 0f, 0f);
            } 
            else if (this.tiltAxis == BodyPosition.Y)
            {
                this.transform.Rotate(0f, -1f * this.currentRotation, 0f);
            }
            else if (this.tiltAxis == BodyPosition.Z)
            {
                this.transform.Rotate(0f, 0f, -1f * this.currentRotation);
            }

            this.currentRotation = 0f;
        }
    }

    private void CheckTiltInput()
    {
        if (Input.GetKey(KeyCode.T))
        {
            this.shouldTilt = !this.shouldTilt;
            Debug.Log("Tilting: " + this.shouldTilt);
        }
    }
}
