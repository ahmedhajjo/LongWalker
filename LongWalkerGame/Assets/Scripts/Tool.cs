using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {

    public List<InGameObject> createPrefabs;
    public List <GameObject> createObjectsAsGameObj;

    public GameObject Pfabs;




    public void IstanObjects(Vector3 pos)
    {
        if (createPrefabs == null)
        {
            createPrefabs = new List<InGameObject>();
        }

        if (createObjectsAsGameObj == null)
        {
            createObjectsAsGameObj = new List<GameObject>(); 
        }

        GameObject g = (GameObject)Instantiate(Pfabs, pos, Quaternion.Euler(0, 0, 0));
        createPrefabs.Add (new InGameObject (g));
        createObjectsAsGameObj.Add(g);


    }



    public void destroyObject(InGameObject toDestroy)
    {
        createObjectsAsGameObj.Remove(toDestroy.get());
        createPrefabs.Remove(toDestroy);
        DestroyImmediate(toDestroy.get());

            
    } 

   [System.Serializable]
    public class InGameObject
    {
        public GameObject myObject;
        public InGameObject(GameObject myObj)
        {
            myObject = myObj;
        }

        public GameObject get()
        {
            return myObject;
        }

    }

}
