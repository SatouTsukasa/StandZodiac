using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{

    private GameObject pauseObject;
    private GameObject pauseTap;

    string Scenename;

    //private GameObject script;

    // Start is called before the first frame update
    void Start()
    {
        pauseObject = transform.Find("OptionPanel").gameObject;
        pauseTap = GameObject.Find("Canvas");
        pauseObject.SetActive(false);
        pauseTap.GetComponent<Tap>().enabled = true;
        Time.timeScale = 1f;

        Scenename = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Stop() {

        pauseObject.SetActive(true);
        pauseTap.GetComponent<Tap>().enabled = false;
        Time.timeScale = 0f;
    }

    public void Button_Start() {

        pauseObject.SetActive(false);
        pauseTap.GetComponent<Tap>().enabled = true;
        Time.timeScale = 1f;
    }

    public void Button_ReStart()
    {

        SceneManager.LoadScene(Scenename);
    }

    public void Button_OP_Title()
    {
        SceneManager.LoadScene("Title");
    }


}
