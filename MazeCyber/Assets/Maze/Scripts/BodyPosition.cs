using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    public static Vector3 bodyPosition;
    public static Vector3 bodyRotation;

    public static readonly string X = "X";
    public static readonly string Y = "Y";
    public static readonly string Z = "Z";

    // Start is called before the first frame update
    void Start()
    {
        bodyPosition = this.gameObject.transform.position;
        bodyRotation = this.gameObject.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        bodyPosition = this.gameObject.transform.position;
        bodyRotation = this.gameObject.transform.rotation.eulerAngles;
    }

    public static string GetTiltAxis()
    {
        bool zAxisTop = (bodyRotation.y >= 0 && bodyRotation.y <= 45) || (bodyRotation.y >= 315 && bodyRotation.y <= 360);
        bool zAxisBot = (bodyRotation.y >= 135 && bodyRotation.y <= 225);


        if (zAxisTop || zAxisBot) 
        {
            return Z; 
        }

        return X;
    }
}
