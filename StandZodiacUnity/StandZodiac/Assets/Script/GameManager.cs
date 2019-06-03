using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main
{
    public class GameManager : MonoBehaviour
    {

        private const int MAX_SCORE = 999999;

        public GameObject textScoreNumber;

        private int score = 0;//スコア
        private int displayScore = 0;//表示用スコア

        public int SceneNumber;

        private GameObject Player;
        private GameObject PlayerSave;
        private Save save;
        private GameObject Savedata;

        // Start is called before the first frame update
        void Start()
        {

            RefreshScore();
            /*
            Player = GameObject.Find("Player");
            PlayerSave = GameObject.Find("PlayerSave");
            save = PlayerSave.GetComponent<Save>();
            Savedata = save.SavePlayer;


            if (Player == null) {
                Instantiate(Savedata);
            }
            */
        }

        // Update is called once per frame
        void Update()
        {
            /*timer += Time.deltaTime;
            if(timer > 3 && timerbool == true)
            {
                Time.timeScale = 0;
                Debug.Log("asdfghjkl");
                messageStart.enabled = false;
                timerbool = false;
                timer = 0;
                //Time.timeScale = 1;
            }*/

            if (score > displayScore)
            {
                displayScore += 10;

                if (displayScore > score)
                {
                    displayScore = score;
                }

                RefreshScore();
            }
            //Debug.Log(score);
        }

        //スコア加算
        public void AddScore(int val)
        {
            score += val;
            if (score > MAX_SCORE)
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
            Invoke("ChangeScene", 1.5f);
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

        public void ChangeScene()
        {
            SceneManager.LoadScene("Player");
        }



    }
}
