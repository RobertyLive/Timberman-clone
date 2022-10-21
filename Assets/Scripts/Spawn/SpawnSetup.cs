using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSetup : MonoBehaviour
{
    public List<GameObject> woods;
    public GameObject parent;
    public Transform local;
    public void Spaw()
    {
        Debug.Log("Spaw");
        var obj = Instantiate(woods[Random.Range(0, woods.Count)]);
        obj.transform.SetParent(parent.transform);
        obj.transform.position = local.transform.position;
        //Instantiate
    }
}
