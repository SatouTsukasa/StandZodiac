using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random.Range;


public class Boss : MonoBehaviour
{

    //private float XUp = 650;
    //private float YUp = 1040;
    //private float XDown = 45;
    //private float YDown = 850;

    private float BossMove_X;
    private float BossMove_Y;

    private float BossX;
    private float BossY;

    //private Vector3 Bosspos = transform.position;

    // Start is called before the first frame update
    void Start()
    {
        BossMove();
    }

    // Update is called once per frame
    void Update()
    {
        BossX = transform.position.x;
        BossY = transform.position.y;

        
    }

    void BossMove() {

        BossMove_X = Random.Range(650f, 45f);
        BossMove_Y = Random.Range(1040f, 850f);

        transform.position = new Vector3(BossMove_X, BossMove_Y, 0);
    }

    void BossShot() {

    }

}
