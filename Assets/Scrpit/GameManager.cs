using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("List")]
    public List<Color> colorList = new List<Color>();
    public List<GameObject> levelList = new List<GameObject>();

    [Header("Gameobject")]
    public GameObject level;
    public GameObject car;
    public GameObject cuurentCar;
    public GameObject UIManager;

    [Header("Text")]
    [SerializeField] Text countDownText;
    [SerializeField] Text levelCountText;

    [Header("İnt")]
    [SerializeField]
    int entranceNumber = 0;
    [SerializeField]
    int levelNumber = 0;
    
    [Header("Float")]
    float currentTime = 0f;
    [SerializeField]
    float startingtime = 30f;

    [Header("Bool")]
    public bool timeStart = false;

    private void Awake()
    {
        var level = Resources.LoadAll("Level", typeof(GameObject));
        foreach (GameObject e in level)
        {
            levelList.Add(e);
        }    
    }
    private void FixedUpdate()
    {
        timeCounter();
    }

    void timeCounter()
    {
        if (timeStart)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");

            if(currentTime <= 0)
            {
                currentTime = startingtime;
                Destroy(cuurentCar);
                CarSpawn(level, entranceNumber);
            }
        }
    }

    public void CarSpawn(GameObject level, int entranceNumber)
    {
        timeStart = false;
        Vector2 pos = level.GetComponent<LevelManager>().entrancesList[entranceNumber].transform.position;
        level.GetComponent<LevelManager>().entrancesList[entranceNumber].SetActive(true);
        level.GetComponent<LevelManager>().targetsList[entranceNumber].SetActive(true);
        car.GetComponent<SpriteRenderer>().color = new Color(colorList[entranceNumber].r, colorList[entranceNumber].g, colorList[entranceNumber].b);
        cuurentCar = Instantiate(car, pos, Quaternion.identity);
        cuurentCar.transform.rotation = level.GetComponent<LevelManager>().entrancesList[entranceNumber].transform.rotation;
    }

    public void CarRestart()
    {
        CarSpawn(level, entranceNumber);
    }

    public void NewCarEntance()
    {
        if(entranceNumber == level.GetComponent<LevelManager>().entrancesList.Count-1)
        {
            Destroy(level);
            UIManager.GetComponent<UIManager>().NextLevel((levelNumber+1).ToString());
        }
        else 
        { 
            level.GetComponent<LevelManager>().entrancesList[entranceNumber].SetActive(false);
            level.GetComponent<LevelManager>().targetsList[entranceNumber].SetActive(false);
            entranceNumber++;
            currentTime = startingtime;
            countDownText.text = currentTime.ToString("0");
            CarSpawn(level, entranceNumber);
        }
    }
    public void levelCreate()
    {
        currentTime = startingtime;
        countDownText.text = currentTime.ToString("0");
        timeStart = false;
        entranceNumber = 0;
        if(levelNumber == levelList.Count ) { levelNumber = 0; UIManager.GetComponent<UIManager>().NextLevel("Level Finish Go Level 1"); }
        else {
        levelCountText.text = "Level : " + (levelNumber + 1).ToString();
        level = Instantiate(levelList[levelNumber]);
        foreach(GameObject g in level.GetComponent<LevelManager>().entrancesList) { g.SetActive(false); }
        foreach (GameObject g in level.GetComponent<LevelManager>().targetsList) { g.SetActive(false); }
        CarSpawn(level, entranceNumber);
        levelNumber++;
        }
    }

}
