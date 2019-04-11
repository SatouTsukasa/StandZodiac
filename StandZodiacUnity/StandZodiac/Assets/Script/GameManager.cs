using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private const int MAX_SCORE = 999999;

    public GameObject textScoreNumber;

    private int score = 0;//スコア
    private int displayScore = 0;//表示用スコア

    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(score > displayScore)
        {
            displayScore += 10;

            if(displayScore > score)
            {
                displayScore = score;
            }

            RefreshScore();
        }
        //Debug.Log(score);
    }

    //スコア�?�?
    public void AddScore(int val)
    {
        score += val;
        if(score > MAX_SCORE)
        {
            score = MAX_SCORE;
        }
    }

    //スコア更新
    void RefreshScore()
    {
        textScoreNumber.GetComponent<Text>().text = displayScore.ToString();
    }



    public void ButtonClicked_Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void ButtonClicked_CharaSelect()
    {
        SceneManager.LoadScene("CharaSelect");
        Debug.Log("OK?");
    }

    public void ButtonClicked_Talk()
    {
        SceneManager.LoadScene("talk");
    }


}

