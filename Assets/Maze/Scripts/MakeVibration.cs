using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVibration : MonoBehaviour
{
    private enum EFFECT_TYPE { CONSTANT, VISCOUS, SPRING, FRICTION, VIBRATE };

    private EFFECT_TYPE effectType = EFFECT_TYPE.VISCOUS; 
    
    private double Gain = 0.333f;
    private double Magnitude = 0.333f;
    private double Frequency = 200.0f;
    private double Duration = 1.0f;
    private double[] Position = { 0.0, 0.0, 0.0 }; // Dummy position
    private double[] Direction = { 0.0, 1.0, 0.0 }; // Direction of vibration

    private HapticPlugin[] devices;
    private int[] FXID;

    private bool vibrationOn;

    // Start is called before the first frame update
    void Start()
    {
        this.devices = (HapticPlugin[]) Object.FindObjectsOfType(typeof(HapticPlugin));
        
        if (this.devices.Length < 1)
        {
            Debug.Log("No haptic devices!");
        }
        
        this.FXID = new int[this.devices.Length];

        // Generate an OpenHaptics effect ID for each of the devices.
        for (int i = 0; i < this.devices.Length; i++)
        {
            this.FXID[i] = HapticPlugin.effects_assignEffect(this.devices[i].configName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CollideAction.isColliding && !this.vibrationOn)
        {
            this.StartEffect();
        } else if (!CollideAction.isColliding && this.vibrationOn)
        {
            this.StopEffect();
        }
    }

    private void StartEffect()
    {
        for (int i = 0; i < this.devices.Length; i++)
        {
            HapticPlugin device = this.devices[i];
            int ID = this.FXID[i];

            // Assign IDs to devices that haven't been assigned
            if (ID == -1)
            {
                this.FXID[i] = HapticPlugin.effects_assignEffect(this.devices[i].configName);
                ID = this.FXID[i];

                if (ID == -1)
                {
                    Debug.LogError("Unable to assign Haptic effect.");
                    continue;
                }
            }

            // Send the current effect settings to OpenHaptics.
            HapticPlugin.effects_settings(
                device.configName,
                ID,
                Gain,
                Magnitude,
                Frequency,
                Position,
                Direction);

            HapticPlugin.effects_type(
                device.configName,
                ID,
                (int)effectType);

            HapticPlugin.effects_startEffect(device.configName, ID);
            this.vibrationOn = true;
        }
    }

    private void StopEffect()
    {
        for (int i = 0; i < this.devices.Length; i++)
        {
            HapticPlugin device = this.devices[i];
            int ID = this.FXID[i];

            if (ID != -1)
            {
                HapticPlugin.effects_startEffect(device.configName, ID);
                this.vibrationOn = false;
            }
        }
    }
}
