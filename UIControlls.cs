using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlls : MonoBehaviour
{
    public Text score;
    public Text HScore;
    static int i = 0;

    //Use this for initialization
    void Start()
    {
        //PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    void Update()
    {
        HighScore();
        HScore.text = PlayerPrefs.GetInt("HScore").ToString();

    }
    public void Play()
    {
        i++;
        score.text = i.ToString();
        PlayerPrefs.SetInt("score", i);
        HighScore();
    }
    public void HighScore()
    {
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("HScore"))
        {
            int h = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("HScore", h);
        }
    }
}
