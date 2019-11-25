using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that changes the a game object color by cycling through the HSV colours in ascending order
public class CycleColour1 : MonoBehaviour
{
    private bool ShouldCycle = false;
    private readonly List<Color> colours = new List<Color>();
    private volatile int index = 0;
    Renderer rend;
    private Color InitialColor;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckCycleInput", 0f, 0.25f);


        for (int h = 0; h <= 360; h++)
        {
            for (int s = 95; s <= 100; s++)
            {
                float hue = (float)h / 360;
                float saturation = (float)s / 100;

                this.colours.Add(Color.HSVToRGB(hue, saturation, 1.0f));
            }
        }

        rend = GetComponent<Renderer>();
        InitialColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.ShouldCycle)
        {
            if (this.index >= this.colours.Count)
            {
                this.index = 0;
            }

            rend.material.color = this.colours[this.index];
            this.index++;
        }
    }

    private void CheckCycleInput()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            this.ShouldCycle = !this.ShouldCycle;

            if (!this.ShouldCycle)
            {
                rend.material.color = InitialColor;
            }
        }
    }
}
