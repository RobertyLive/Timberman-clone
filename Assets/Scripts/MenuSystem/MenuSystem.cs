using System.Collections;
using System.Collections.Generic;
using UISETUP;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public enum StateOfGame
{
    MENU,
    INGAME,
    GAMEOVER
}

public class MenuSystem : MonoBehaviour
{
    public StateOfGame game;

    public CinemachineVirtualCamera virtualCamera;

    public Atack s_atack;
    public UISetup s_uiSetup;
    public Player s_player;
    public DificutySystem diff;

    [Header("CORES LERP")]
    public Color start;
    public Color end;

    public GameObject text;

    public void Awake()
    {
        game = StateOfGame.MENU;
        ShowByStartGame();
    }

    public void ShowByStartGame()
    {
        if (game == StateOfGame.MENU)
        {
            s_atack.enabled = false;
            s_uiSetup.enabled = false;
            s_player.enabled = false;
            diff.enabled = false;
            text.SetActive(false);
        }
    }

    
    public void OnStartGame()
    {
        text.SetActive(true);
        game = StateOfGame.INGAME;
        s_uiSetup.ui_text.color = Color.Lerp(start, end, 1/Time.deltaTime);
        virtualCamera.enabled = false;
        StartCoroutine(OnStarterGame());
    }

    IEnumerator OnStarterGame()
    {

        yield return new WaitForSeconds(2f);
        s_atack.enabled = true;
        s_uiSetup.enabled = true;
        s_player.enabled = true;
        diff.enabled = true;

    }


}
