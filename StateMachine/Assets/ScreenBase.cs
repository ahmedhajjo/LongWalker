using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBase : MonoBehaviour {
    public virtual void UpdateScreen(ScreenManager SM) {
        Debug.Log("Base");
    }
}
