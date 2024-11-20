using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score; //Static dememizin sebebi her scriptte g�r�ntelebilmek �a��rabilmek 
    public static int HiScore;
    public Text scoretext; //Scoreyi tan�ml�yoruz
    public Text maxscore;
    public float enyuksek;
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            HiScore = PlayerPrefs.GetInt("HiScore");
        }
        maxscore.text = "Hi score: " + enyuksek.ToString();
        score = 0; //Ba�lang��ta score 0 
       
    }

    void Update()
    {
        if (score > HiScore)
        {
            HiScore = score;
            PlayerPrefs.SetInt("HighScore",HiScore);
        }
        scoretext.text = "Score: " + Mathf.Round(score); //Score de�erini yaz�ya �evir scoreyi yazd�r
        maxscore.text = "Hi score: " + HiScore.ToString();
        enyuksek = HiScore;
        
    }
}
