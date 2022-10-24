using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DificutySystem : MonoBehaviour
{
    public Text text_animado;
    public float timeToLevel;
    [HideInInspector]public int i=1;


    public GameObject text;
    public void Update()
    {

        if (Time.time > timeToLevel)
        {

            string b = "Level " + i.ToString();
            i++;
            AlteraText(b);
            Transição(true);

            timeToLevel += Time.time;
        }
    }


    public void AlteraText(string a)
    {
        text_animado.text = a;
    }

    public void Transição(bool a)
    {
        text_animado.transform.gameObject.SetActive(a);
    }
}
