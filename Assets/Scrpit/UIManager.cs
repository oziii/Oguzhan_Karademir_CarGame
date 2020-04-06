using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject NextLevelMenu;
    public GameObject GameScene;
    public GameObject GameManager;

    [SerializeField] Text levelTitle;

    public void gameStart()
    {
        StartMenu.SetActive(false);
        GameScene.SetActive(true);
        GameManager.GetComponent<GameManager>().levelCreate();
    }

    public void gameExit()
    {
        Application.Quit();
    }

    public void NextLevel(string levelName)
    {
        GameScene.SetActive(false);
        levelTitle.text = "Level : " + levelName;
        NextLevelMenu.SetActive(true);
    }

    public void NextLevelGet()
    {
        NextLevelMenu.SetActive(false);
        GameScene.SetActive(true);
        GameManager.GetComponent<GameManager>().levelCreate();
    }

}
