using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    public static Vector3 bodyPosition;
    public static Vector3 bodyRotation;

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
}
