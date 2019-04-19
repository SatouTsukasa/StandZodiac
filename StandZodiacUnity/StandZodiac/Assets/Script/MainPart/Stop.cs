using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{

    public GameObject pauseObject;
    public GameObject pausePlayer;

    //private GameObject script;

    // Start is called before the first frame update
    void Start()
    {
        pauseObject.SetActive(false);
        pausePlayer.GetComponent<Player>().enabled = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Stop() {

        pauseObject.SetActive(true);
        pausePlayer.GetComponent<Player>().enabled = false;
        Time.timeScale = 0f;
    }

    public void Button_Start() {

        pauseObject.SetActive(false);
        pausePlayer.GetComponent<Player>().enabled = true;
        Time.timeScale = 1f;
    }

    public void Button_ReStart()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void Button_OP_Title()
    {
        SceneManager.LoadScene("Title");
    }


}
