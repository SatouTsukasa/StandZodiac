using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    private Vector3 PlayerPos;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }
        PlayerPos = Player.transform.position;
        this.transform.LookAt(Player.transform);
    }

 
}
