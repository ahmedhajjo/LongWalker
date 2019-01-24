using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour {
    public bool CanEnd = false;

    private void OnTriggerEnter(Collider other)
    {
        if (CanEnd && other.tag == "Player")
        {
            SceneManager.LoadScene(2);
            Cursor.visible = true;
        }
    }
}
