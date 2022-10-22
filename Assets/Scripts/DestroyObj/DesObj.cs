using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesObj : MonoBehaviour
{
    public bool startGame;
    private void Update()
    {
        if(transform.position.y < -3)
        {
            DestroyGameObj();
        }
    }
    public void DestroyGameObj()
    {
        Destroy(this.gameObject);
    }
}
