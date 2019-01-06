using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float interval;
    private float timer;
    public int numberofEnemies;

    // Use this for initialization
    void Start () {
        interval = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        spawnEnemies();
    }

    public void spawnEnemies()
    {
        if (numberofEnemies >= 0 && Time.time > timer)
        {
            timer = Time.time + 1 / interval;
            SpawnNext();
        }

    }

    void SpawnNext()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        numberofEnemies--;
    }
}
