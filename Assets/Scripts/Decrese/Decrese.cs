using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//adicionar filhos naquela positions do spaw;
public class Decrese : MonoBehaviour
{
    public Player player;
    public float cut;


    public SpawnSetup spawnSetup;


    public bool isAdd=false;
    private void Start()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<Player>();
    }


    public void Decrescer()
    {
        if (!player.wasCut)
        {
            int i = 0;
            do
            {
                //spawnSetup.woods.Remove(player.obj);
                transform.position -= new Vector3(0, cut, 0);
                spawnSetup.Spaw();
            } while (i > spawnSetup.woods.Count);

            
            player.wasCut = false;
        }


    }
}
