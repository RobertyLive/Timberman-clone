using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{



    [SerializeField] private float distanceUP, distanceOtherSide;

    [SerializeField] private LayerMask layerBrach;


    public bool isLineVerticalCut;
    //public bool isLineHorizontal;

    //float value;

    private void Update()
    {
        LineOnHead();
    }
    private void LineOnHead()
    {
        isLineVerticalCut = Physics2D.Raycast(transform.position, Vector2.up, distanceUP, layerBrach);
    }

    //Decidi fazer por Overlap
    //private void LineOnVertical()
    //{
    //    isLineHorizontal = Physics2D.Raycast(transform.position, Vector2.up, distanceUP, layerBrach);
    //}


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.up*distanceUP);
        //Gizmos.DrawRay(transform.position, Vector2.left*distanceOtherSide);   
    }
}
