using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BirdJump : MonoBehaviour
{
    Rigidbody2D bird;
    public static int score = 0;
    public Text scoreText;
    public Text HScore;
   // static int i = 0;

    // Use this for initialization;
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bird.velocity = new Vector2(0, 4);
        }

        HighScore();
        HScore.text = PlayerPrefs.GetInt("HScore").ToString();
        scoreText.text = score.ToString();

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "point")
        {
            score = score + 5;
            HScore.text = score.ToString();
            PlayerPrefs.SetInt("score", score);
            HighScore();
            return;
        }
    }
    //public void Play()
   // {
        //i++;
       // HScore.text = score.ToString();
       // PlayerPrefs.SetInt("score", score);
        //HighScore();
   // }
    public void HighScore()
    {
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("HScore"))
        {
            int h = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("HScore", h);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "pipes" || collision.gameObject.tag == "land")
        {
            Destroy(gameObject);
            score = 0;
            SceneManager.LoadScene(0);

        }

    }
   
}
