using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{

    Enemy enemy;
    
    public GameObject player;


    private float BossMove_X;
    private float BossMove_Y;
    private float step = 100f;

    const float NOMALMOVE = 100f;
    const float TACKLEMOVE = 500f;

    const float TACKLE_TIME_N = 8;
    private float Tackle_time = TACKLE_TIME_N;

    Spaceship spaceship;

    enum STATUS {
        MOVE,
        ATTACK,
        BACK
    };

    private STATUS Status = STATUS.MOVE;

    Vector2 target;
    Vector2 TacklePos;


    // Start is called before the first frame update
    void Start()
    {
        BossMove_X = Random.Range(650f, 45f);
        BossMove_Y = Random.Range(1040f, 850f);

        target.x = BossMove_X;
        target.y = BossMove_Y;

        enemy = GetComponent<Enemy>();
        spaceship = GetComponent<Spaceship>();
        //Player = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        //PlayerPos = player.transform.position;
        BossMove();



        /*if (enemy.hp <= 25)
        {



        }*/

        Tackle_time -= Time.deltaTime;

        if(Tackle_time < 0 && Status == STATUS.MOVE) {
          Debug.Log("ababa");
            
          TacklePos = transform.position;
            target = player.transform.position;
            step = TACKLEMOVE;
            Status = STATUS.ATTACK;
            spaceship.enabled = false;

        }




        //Debug.Log(Tackle_time);

    }


    void BossMoveTarget() {

        BossMove_X = Random.Range(650f, 45f);
        BossMove_Y = Random.Range(1040f, 850f);

        target.x = BossMove_X;
        target.y = BossMove_Y;
    }


    void BossMove() {

        transform.position = Vector2.MoveTowards(transform.position, target, step * Time.deltaTime);

        if (1f > Vector2.Distance(transform.position, target))
        {
            switch (Status)
            {
                case STATUS.MOVE:
                    spaceship.enabled = true;
                    BossMoveTarget();
                    

                    break;

                case STATUS.ATTACK:
                    target = TacklePos;
                    Status = STATUS.BACK;
                    Debug.Log("aaaaaaaaa");
                    

                    break;


                case STATUS.BACK:
                    
                    Status = STATUS.MOVE;
                    Tackle_time = TACKLE_TIME_N;
                    step = NOMALMOVE;

                    break;

            }
            
        }

//Debug.Log(transform.position);

    }
    /*

    void Oushi_Tackle() {

        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, Tackle * Time.deltaTime);

        if (1f > Vector2.Distance(transform.position, PlayerPos))
        {
            BossMoveTarget();
            BossMove();
        }


    }
    */
}
