using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool Tackle;

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
    public void ShotPU(Transform origin, bool  PU2, bool PU3, bool PU4, bool PU5)
    {
        Instantiate(bullet2, origin.position, origin.rotation);
        if(PU2 == true)
        {
            Instantiate(bullet3, origin.position, origin.rotation);
            if (PU3 == true)
            {
                Instantiate(bullet4, origin.position, origin.rotation);
                if (PU4 == true){
                    Instantiate(bullet5, origin.position, origin.rotation);
                }
            }
        }
    }

    // 機体の移動
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        
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
}
