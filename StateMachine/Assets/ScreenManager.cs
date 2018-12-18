using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {
    public ScreenBase currentScreem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentScreem.UpdateScreen(this);
	}

    public void ChangeScreen(ScreenBase newScreen) {
        currentScreem.gameObject.SetActive(false);
        currentScreem = newScreen;
        currentScreem.gameObject.SetActive(true);
    }
}
