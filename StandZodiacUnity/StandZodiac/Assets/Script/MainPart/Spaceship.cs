using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2Dコンポ��Eネントを忁E��にする
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピ��EチE
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    //追尾する感要E
    public float TackleDelay;

    // 弾のPrefab
    public GameObject bullet;

    //パワーアチE�E弾
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;

    // 弾を撃つかどぁE��
    public bool canShot;

    public bool div;

    public GameObject divEnemy;

    // 爁E��のPrefab
    public GameObject explosion;

    public GameObject Player;

    // アニメーターコンポ��EネンチE
    private Animator animator;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポ��Eネントを取征E
        animator = GetComponent<Animator>();

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 爁E��の作��E
    public void Explosion()
    {
        //Debug.Log("aaa");
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // 弾の作��E
    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);

    }

    // パワーアチE�E弾の作��E
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

    // 機体��E移勁E
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }

    // アニメーターコンポ��Eネント��E取征E
    public Animator GetAnimator()
    {
        return animator;
    }

    public void Compliance()
    {
        // ターゲチE��との座標間隔を取征E
        //Vector3 diff = (Player.transform.position - this.transform.position).normalized;
        // 回転させる　Quaternion.FromToRotation�E�第1引数 から 第2引数 への回転をさせる�E�E
        //this.transform.rotation = Quaternion.FromToRotation(Vector3.left, diff);


    }

    public void Division()
    {
        for(int i = 0;i < 2; i++)
        {
            Debug.Log(i);
            GameObject DivEnemy = (GameObject)Instantiate(divEnemy) as GameObject;
            DivEnemy.layer = LayerMask.NameToLayer("DivEnemy");
            //DivEnemy.transform.position = Vector3.MoveTowards(transform.position,
            //new Vector3(transform.position.x + Random.Range(-200, 200), transform.position.y + Random.Range(-30, 0),transform.position.z), 0.01f);
        }
        
    }
}
