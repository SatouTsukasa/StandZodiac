using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private float step = 2f;

    Vector3 target;

    //private Vector3 Bosspos = transform.position;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BossMove();
        //BossX = transform.position.x;
        //BossY = transform.position.y;

    }

    void BossMove() {

        Debug.Log("ababa");

        BossMove_X = Random.Range(650f, 45f);
        BossMove_Y = Random.Range(1040f, 850f);

        target.x = BossMove_X;
        target.y = BossMove_Y;


        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);

        if(target.x < 45f && target.y > )

    }

    void BossShot() {

    }

}
