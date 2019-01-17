using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighController : MonoBehaviour {
    Light TheLight;  //Light Component
    MeshRenderer meshRender;
    public float miniTimeBeforFlickers; //Minim Flicker Time
    public float maxTimeAfterFlickers;  //Max Time AfterFliker.
	// Use this for initialization
	void Start () {

        TheLight = GetComponent<Light>();
        meshRender = GetComponent<MeshRenderer>();
        StartCoroutine("MakeflickerLight"); //Start IENUMERATOR
	}
    IEnumerator MakeflickerLight()
    {
        while (true) //While loop 
        {
            yield return new WaitForSeconds(Random.Range(miniTimeBeforFlickers, maxTimeAfterFlickers));
            TheLight.enabled = !TheLight.enabled; //Enable , Disable light.
            meshRender.enabled = !meshRender.enabled;
        }
    }
}
