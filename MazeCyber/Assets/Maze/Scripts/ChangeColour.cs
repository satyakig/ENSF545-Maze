using System.Collections.Generic;
using UnityEngine;

// Class that changes a game object's color by cycling through all the HSV colours
public class ChangeColour : MonoBehaviour
{
    private readonly List<Color> colours = new List<Color>();
    private volatile int colourIndex = 0;
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        string name = this.gameObject.name;

        // Create an array of all the HSV colours
        if (name.Contains("Bad"))
        {
            this.colours.Add(new Color(1f, 0f, 0f));
            //for (int h = 0; h <= 30; h++)
            //{
            //    float hue = (float)h / 360;
            //    this.colours.Add(Color.HSVToRGB(hue, 1.0f, 1.0f));
            //}
        }
        else if (name.Contains("Good"))
        {
            this.colours.Add(new Color(0f, 1f, 0f));
            //for (int h = 121; h <= 151; h++)
            //{
            //    float hue = (float)h / 360;
            //    this.colours.Add(Color.HSVToRGB(hue, 1.0f, 1.0f));
            //}
        }
        else
        {
            for (int h = 0; h <= 360; h++)
            {
                //float hue = (float)h / 360;
                //this.colours.Add(Color.HSVToRGB(hue, 1.0f, 1.0f));
            }

        }

        this.objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change the object's colour
        if (this.colours.Count > 0)
        {
            if (this.colourIndex >= this.colours.Count)
            {
                this.colourIndex = 0;
            }

            this.objectRenderer.material.color = this.colours[this.colourIndex];
            this.colourIndex++;
        }
    }
}
