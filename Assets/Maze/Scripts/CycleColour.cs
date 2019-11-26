using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that changes a game object's color by cycling through all the HSV colours
public class CycleColour : MonoBehaviour
{
    private bool shouldCycle = false;
    private readonly List<Color> colours = new List<Color>();
    private volatile int colourIndex = 0;
    private Color initialColour;
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckCycleInput", 0f, 0.15f);

        // Create an array of all the HSV colours
        if (this.gameObject.name.Contains("V"))
        {
            for (int h = 0; h <= 360; h++)
            {
                for (int s = 95; s <= 100; s++)
                {
                    float hue = (float)h / 360;
                    float saturation = (float)s / 100;

                    this.colours.Add(Color.HSVToRGB(hue, saturation, 1.0f));
                }
            }
        } else
        {
            for (int h = 360; h >= 0; h--)
            {
                for (int s = 100; s >= 95; s--)
                {
                    float hue = (float)h / 360;
                    float saturation = (float)s / 100;

                    this.colours.Add(Color.HSVToRGB(hue, saturation, 1.0f));
                }
            }

        }

        this.objectRenderer = GetComponent<Renderer>();
        this.initialColour = objectRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Change the object's colour
        if (this.shouldCycle)
        {
            if (this.colourIndex >= this.colours.Count)
            {
                this.colourIndex = 0;
            }

            this.objectRenderer.material.color = this.colours[this.colourIndex];
            this.colourIndex++;
        }
    }

    private void CheckCycleInput()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            this.shouldCycle = !this.shouldCycle;

            if (!this.shouldCycle)
            {
                this.objectRenderer.material.color = this.initialColour;
            }
        }
    }
}
