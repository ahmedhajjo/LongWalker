using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCam : MonoBehaviour
{
    Vector2 mouseControl;
    Vector2 smooth;
    public float sensitivity = 1.0f;
    public float smoothing = 1.0f;
    GameObject Player;
    // Use this for initialization
    void Start()
    {



        Player = this.transform.parent.gameObject;


    }
    // Update is called once per frame
    void Update()
    {
        //MOUSE CAMERA CONTROL  
        // CAMERA SMOOTH

        Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mc = Vector2.Scale(mc, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, mc.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mc.y, 1f / smoothing);
        mouseControl += smooth;
        transform.localRotation = Quaternion.AngleAxis(-mouseControl.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseControl.x, Player.transform.up);
        // ROTATION LOCKED Y AXIS DEGREE -90 to 90  
        // MOUSE CURSOR DISABLED WHILE GAME IS PLAYING
        mouseControl.y = Mathf.Clamp(mouseControl.y, -90f, 90f);
    }
}
