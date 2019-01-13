using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighController : MonoBehaviour {

    Light light;

    public float miniTimeBeforFlickers;
    public float maxTimeAfterFlickers;




	// Use this for initialization
	void Start () {

        light = GetComponent<Light>();

        StartCoroutine("MakeflickerLight");
	}

    IEnumerator MakeflickerLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(miniTimeBeforFlickers, maxTimeAfterFlickers));
            light.enabled = !light.enabled;
        }
    }

    // Update is called once per frame
    void Update () {
		

        
	}
}
