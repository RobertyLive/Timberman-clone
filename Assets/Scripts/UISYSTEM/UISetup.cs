using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISETUP
{
    public class UISetup : MonoBehaviour
    {
        [Header("Setup for Barra")]
        public Image image;
        public float time = 0;
        public float cont = 0;
        public Color colorBarra;

        public Text ui_text;
        private int som;
        public int reset = 0;
        public void AddPoint(int i = 1)
        {
            som += 1;
            ui_text.text = som.ToString();
        }
        public void ResetPoint()
        {
            ui_text.text = som.ToString();
            som = 0;
        }

        public void GameOverReset()
        {
            ui_text.text = reset.ToString();
        }

        public void Timer(Atack a)
        {
            while (a.enabled != false && image.fillAmount > 0.01f && cont >= time)
            {
                Debug.Log("Error");
                time = cont + 1;
                image.fillAmount -= 0.07f;
                if(image.fillAmount < 0.01f)
                {
                    Debug.Log("Error menor");
                    FindObjectOfType<Player>().Dead();
                    break;
                }

                StartCoroutine(Timerr());
            }
        }

        public IEnumerator Timerr()
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.3f));
            cont = time;
        }

        public void AddEnergy()
        {
            Color beforeColor = image.color;
            image.color = colorBarra;
            image.fillAmount += 0.03f;
            image.color = beforeColor;
        }

    }

    

}
