using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



namespace UISETUP
{
    public class UISetup : MonoBehaviour
    {
        

        [Header("PANEL")]
        public GameObject panel;
        public int bestScore;
        public Text valueScore;
        
        [Header("Setup for Barra")]
        public Image image;
        public float time = 0;
        public float cont = 0;
        public Color colorBarra;

        public Text ui_text;
        public GameObject ui_textObj;
        private int som;
        public int reset = 0;

        public bool isLoser;


        public GameObject panelStart;
        public MenuSystem menu;
        public DificutySystem dificutySystem;

        public float speedLife;

        private int contador=1;

        //FAZER SISTEMA DE DIFICULDADE
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
                time = cont + 1;
                if (dificutySystem.i == contador)
                {
                    speedLife += 0.01f;
                }
                image.fillAmount -= speedLife;
                
                if(image.fillAmount < 0.01f)
                {
                    panel.SetActive(true);
                    SetInfor();
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

        public void SetInfor()
        {
            valueScore.text = ui_text.text;
            ui_textObj.SetActive(false);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void StartGameButon()
        {
            panelStart.SetActive(false);
            menu.OnStartGame();
        }
    }

    

}
