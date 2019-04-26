using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピード
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    //追尾する感覚
    public float TackleDelay;

    // 弾のPrefab
    public GameObject bullet;

    //パワーアップ弾
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;

    // 弾を撃つかどうか
    public bool canShot;
    //分裂するかどうか
    public bool div;

    //追尾するかどうか
    public bool tackle;
    //蛇行するかどうか
    public bool meander;
    bool mea_flg;


    public GameObject divEnemy;

    // 爆発のPrefab
    public GameObject explosion;

    public GameObject Player;

    // アニメーターコンポーネント
    private Animator animator;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポーネントを取得
        animator = GetComponent<Animator>();

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //UFOの時に実行
        if (meander == true)
        {
            UFO_move();
        }
    }

    // 爆発の作成
    public void Explosion()
    {
        //Debug.Log("aaa");
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // 弾の作成
    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);

    }

    // パワーアップ弾の作成
    public void ShotPU(Transform origin, bool PU3, bool PU4, bool PU5,int TurretCount)
    {
        Instantiate(bullet2, origin.position, origin.rotation);
        if(PU3 == true)
        {

            Instantiate(bullet3, origin.position, origin.rotation);
        }
        if(PU4 == true)
        {
            //Debug.Log("ooooooooooooooooooooooooooo");
            Instantiate(bullet4, origin.position, origin.rotation);

        }
        if(PU5 == true)
        {
            Instantiate(bullet5, origin.position, origin.rotation);
        }

    }

    // 機体の移動
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }

    //UFOの移動処理
    public void UFO_move()
    {
        //UFOの現在地
        Vector2 ufo_pos = this.transform.position;

        if (ufo_pos.x >= 720)  mea_flg = true;

        if (ufo_pos.x <= 0)  mea_flg = false;

        if (mea_flg)
        {
            this.transform.position = new Vector2(ufo_pos.x - 5, ufo_pos.y);
        }
        else
        {
            this.transform.position = new Vector2(ufo_pos.x + 5, ufo_pos.y);
        }
    }

    // アニメーターコンポーネントの取得
    public Animator GetAnimator()
    {
        return animator;
    }

    public void Compliance()
    {
        // ターゲットとの座標間隔を取得
        //Vector3 diff = (Player.transform.position - this.transform.position).normalized;
        // 回転させる　Quaternion.FromToRotation（第1引数 から 第2引数 への回転をさせる）
        //this.transform.rotation = Quaternion.FromToRotation(Vector3.left, diff);
        

    }

    public void Division()
    {
        for(int i = 0;i < 2; i++)
        {
            Debug.Log(i);
            GameObject DivEnemy = (GameObject)Instantiate(divEnemy, new Vector2(transform.position.x + Random.Range(-100, 100), transform.position.y + Random.Range(-30, 0)),Quaternion.identity);
            DivEnemy.layer = LayerMask.NameToLayer("DivEnemy");
            Transform Tf = DivEnemy.GetComponent<Transform>();
            Vector3[] path =
            {
                new Vector3(Tf.localPosition.x * Random.Range(1.1f,1.3f),Tf.localPosition.y * Random.Range(1.05f,1.2f),0f),
                //new Vector3(0f,150f,0f),
            };
            //DOTweenを使ったアニメ作成
            Tf.DOLocalPath(path, 0.5f, PathType.CatmullRom)
                .SetEase(Ease.OutQuad);
            //DivEnemy.transform.position = Vector3.MoveTowards(transform.position,
            //new Vector3(transform.position.x + Random.Range(-200, 200), transform.position.y + Random.Range(-30, 0),transform.position.z), 0.01f);
        }

    }

    public void Tackle()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0f,0f,transform.rotation.z - 90),1f);
    }
}
