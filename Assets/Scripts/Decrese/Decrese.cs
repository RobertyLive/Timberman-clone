using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//adicionar filhos naquela positions do spaw;
public class Decrese : MonoBehaviour
{
    public Player player;
    public float cut;


    public SpawnSetup spawnSetup;

    private void Start()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<Player>();
    }


    public void Decrescer()
    {
        if (!player.wasCut)
        {
            Debug.Log("Descrese");

            //transform.position -= new Vector3(0, cut, 0);
            //FAZER FOREACH PARA DESCE UM POR UM
            foreach (var a in spawnSetup.woods)
            {
                a.transform.position -= new Vector3(0, cut, 0);
            }
            player.wasCut = false;
        }
    }
}
