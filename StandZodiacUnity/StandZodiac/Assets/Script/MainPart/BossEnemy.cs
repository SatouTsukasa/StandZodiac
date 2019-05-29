using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BossEnemy : MonoBehaviour
{

    Enemy enemy;

    public float width;

    int Hp;
    GameObject Player;

    //ふたご座
    //public bool Hutago;
    public GameObject HutagoSister;

    private bool HutagoH;
    private bool mea_flg;

    ///HutagoSister用--------------
    GameObject HSister;
    public bool HutagoS;
    //半径
    public float radius;

    GameObject HutagoT;
    ///----------------------------

    //かに座-----------------------
    public GameObject Bubble;
    private float rate;
    private float rate_span;
    private float intense_rate;
    //-----------------------------



    /// おうし座---------------------------------

    public GameObject player;
    private float BossMove_X;
    private float BossMove_Y;
    private float step = 100f;

    const float NOMALMOVE = 100f;
    const float TACKLEMOVE = 500f;
    const float TACKLE_TIME_N = 8;
    private float Tackle_time = TACKLE_TIME_N;

    Spaceship spaceship;

    enum STATUS
    {
        MOVE,
        ATTACK,
        BACK
    };




    private STATUS Status = STATUS.MOVE;

    Vector2 target;
    Vector2 TacklePos;
    ///------------------------------------------

    public enum SEZA_LIST
    {
        Kani,
        Oushi,
        Hutago,
        Yagi
    };

    public SEZA_LIST Seza = SEZA_LIST.Hutago;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        HutagoH = true;
        Hp = enemy.hp;
        Player = GameObject.Find("Player");


        ///ふたご座---------------------------
        HutagoT = GameObject.Find("EnemyHutago");
        ///-----------------------------------

        ///おうし座---------------------------
        BossMove_X = Random.Range(650f, 45f);
        BossMove_Y = Random.Range(1040f, 850f);

        target.x = BossMove_X;
        target.y = BossMove_Y;

        ///-----------------------------------
        spaceship = GetComponent<Spaceship>();

        ///かに座-----------------------------
        intense_rate = 0.7f;
        ///
    }

    // Update is called once per frame
    void Update()
    {

        switch (Seza)
        {
            case SEZA_LIST.Hutago:

                //ふたご座（男）の現在地
                Vector2 ufo_pos = this.transform.position;

                if (ufo_pos.x >= 640) mea_flg = true;

                if (ufo_pos.x <= 80) mea_flg = false;

                if (Player != null)
                {
                    if (mea_flg)
                    {
                        this.transform.position = new Vector2(ufo_pos.x - 5, ufo_pos.y);
                    }
                    else
                    {
                        this.transform.position = new Vector2(ufo_pos.x + 5, ufo_pos.y);
                    }
                }

                if (enemy.hp <= Hp / 2)
                {
                    spaceship.PU2 = true;
                    if (HutagoH == true)
                    {
                        HutagoPower();
                        HutagoH = false;
                    }
                    //transform.position = new Vector3(transform.position.x + (Mathf.Sin(Time.time * enemy.speed) * 2f), transform.position.y, 0);

                    

                }
                if(HSister == true)
                {
                    
                }
                if (enemy.hp <= 0)
                {
                    Debug.Log("asdcfvgb");

                    Destroy(HSister);
                }

                if (HutagoS == true)
                {

                    if (HutagoT == null)
                    {
                        //Debug.Log("nbvhjkj");
                        //Player.GetComponent<Player>().enabled = false;
                        Destroy(gameObject);
                    }
                    float x = HutagoT.transform.position.x + (Mathf.Cos(Time.time * enemy.speed) * radius);
                    float y = HutagoT.transform.position.y + (Mathf.Sin(Time.time * enemy.speed) * radius);
                    float z = 0f;
                    transform.position = new Vector3(x, y, z);

                }

                break;


            case SEZA_LIST.Kani:
                /*
                //現在地
                Vector2 kani_pos = this.transform.position;

                if (kani_pos.x >= 720)
                    GetComponent<Rigidbody2D>().velocity = transform.right * -1;

                if (kani_pos.x <= 0)
                    GetComponent<Rigidbody2D>().velocity = transform.right;
                */
                Vector2 kani_pos = this.transform.position;
                if (kani_pos.x >= 720) mea_flg = true;
                if (kani_pos.x <= 0) mea_flg = false;

                if (Player != null)
                {
                    if (mea_flg)
                        this.transform.position = new Vector2(kani_pos.x - 5, kani_pos.y);
                    else
                        this.transform.position = new Vector2(kani_pos.x + 5, kani_pos.y);
                }

                rate += Time.deltaTime;
                Kani_shot();
                break;



            ///おうし座----------------------------------------------

            case SEZA_LIST.Oushi:

                BossMove();

                Tackle_time -= Time.deltaTime;

                if (Tackle_time < 0 && Status == STATUS.MOVE)
                {
                    Debug.Log("ababa");

                    TacklePos = transform.position;
                    target = player.transform.position;
                    step = TACKLEMOVE;
                    Status = STATUS.ATTACK;
                    spaceship.enabled = false;

                }

                break;

                Debug.Log(step);

            ///------------------------------------------------------

            case SEZA_LIST.Yagi:


                break;


        }
    }

        void HutagoPower()
        {
            
            GameObject HBrother = GameObject.Find("EnemyHutago");
            GameObject HSister = (GameObject)Instantiate(HutagoSister, new Vector2(HBrother.transform.position.x// + (Mathf.Cos(Time.time * enemy.speed) * radius)
                , HBrother.transform.position.y/* + (Mathf.Sin(Time.time * enemy.speed) * radius)*/), Quaternion.identity);

            Transform Tf = HSister.GetComponent<Transform>();
            Vector3[] path =
            {
                new Vector3(Tf.localPosition.x + (Mathf.Cos(Time.deltaTime * enemy.speed)),Tf.localPosition.y + (Mathf.Sin(Time.deltaTime * enemy.speed)),0f),
                //new Vector3(0f,150f,0f),
            };
            //DOTweenを使ったアニメ作成
            Tf.DOLocalPath(path, 0.5f, PathType.CatmullRom)
                .SetEase(Ease.OutQuad);
            HutagoH = false;
            
            
        }

        void Kani_shot()
        {
            if (rate > intense_rate)
            {
                Vector3 pos = this.transform.position;
                Vector3 n_pos = new Vector3(pos.x, pos.y - 30, pos.z);
                Quaternion k_qua = new Quaternion(0, 0, 180, 0);
                Instantiate(Bubble, n_pos, k_qua);
                rate = 0;

                random_rate();
            }
        }


        /// おうし座

        void BossMoveTarget()
        {

            BossMove_X = Random.Range(650f, 45f);
            BossMove_Y = Random.Range(1040f, 850f);

            target.x = BossMove_X;
            target.y = BossMove_Y;
        }


        void BossMove()
        {

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

        }
        /// --------------------------------------------------------------------------------------------
    void random_rate()
    {
        intense_rate = Random.Range(0.2f, 0.6f);
    }
}

