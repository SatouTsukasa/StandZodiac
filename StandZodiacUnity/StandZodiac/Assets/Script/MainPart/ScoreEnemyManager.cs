using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreEnemyManager : MonoBehaviour
{
    public int POINT = 100;

    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPoint()
    {

        gameManager.GetComponent<GameManager>().AddScore(POINT);

    }
}
