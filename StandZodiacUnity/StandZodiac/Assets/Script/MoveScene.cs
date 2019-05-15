using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked_Title() {
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

    public void G_CaharaMove()
    {
        SceneManager.LoadScene("CharaRoom");
    }

    public void Button_Continue()
    {
        SceneManager.LoadScene("Stage1");
    }

}
