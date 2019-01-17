using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public bool StartSpawn;
    public float SpawnDelay;
    public GameObject[] Spawners;
    public GameObject Zombie;
    public int maxEnemies = 5;
    bool lockScript = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (StartSpawn&& !lockScript)
        {
            lockScript= true;
            StartCoroutine("Spawn", SpawnDelay);
        }
	}
    //A recursive coroutine
    IEnumerator Spawn(float time)
    {
        GameObject[] AliveZombies = GameObject.FindGameObjectsWithTag("Enemy");//will assign all enemies in the scene to an array
        if (AliveZombies.Length < maxEnemies)
        {
            int index = Random.Range(0, Spawners.Length);
            Instantiate(Zombie, Spawners[index].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(3);
        StartCoroutine("Spawn", SpawnDelay);
    }

}
