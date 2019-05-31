using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{

    public GameObject SavePlayer;

    void Awake()
    {
        SavePlayer = GameObject.Find("Player");
        DontDestroyOnLoad(gameObject);
        //SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Start is called before the first frame update
    void Start()
    {
        SavePlayer.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    void Update()
    {
        if (SavePlayer == null) {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        SavePlayer = this.transform.Find("Player").gameObject;

        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            SavePlayer.SetActive(true);
            
        }

        if (SceneManager.GetActiveScene().name == "Stage1_Boss")
        {
            SavePlayer.SetActive(true);
            Debug.Log("aaa");
        }

        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            SavePlayer.SetActive(true);

        }

        if (SceneManager.GetActiveScene().name == "Stage2_Boss")
        {
            SavePlayer.SetActive(true);

        }

        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            SavePlayer.SetActive(true);

        }

        if (SceneManager.GetActiveScene().name == "Stage3_Boss")
        {
            SavePlayer.SetActive(true);

        }

        if (SceneManager.GetActiveScene().name == "BATTLE_1")
        {
            SavePlayer.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "BATTLE_1_WIN")
        {
            SavePlayer.SetActive(false);

        }

        if (SceneManager.GetActiveScene().name == "BATTLE_2")
        {
            SavePlayer.SetActive(false);

        }

        if (SceneManager.GetActiveScene().name == "BATTLE_2_WIN")
        {
            SavePlayer.SetActive(false);

        }

        if (SceneManager.GetActiveScene().name == "BATTLE_3")
        {
            SavePlayer.SetActive(false);

        }

        if (SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(gameObject);
        }


    }

}
