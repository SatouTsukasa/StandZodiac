using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{

    public GameObject player_ob;
    public GameObject Gameover;
    public GameObject Boss;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player_ob == null) {
            Time.timeScale = 0;
            Gameover.SetActive(true);

        }


        if (Boss == null) {


        }

    }


}
