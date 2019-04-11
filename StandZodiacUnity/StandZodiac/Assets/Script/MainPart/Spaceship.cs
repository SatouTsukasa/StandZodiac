using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

// Rigidbody2Dコンポ��Eネントを忁E��にする
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピ��EチE
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    //追尾するかどうか
    public bool Tackle = false;

    // 弾のPrefab
    public GameObject bullet;

    //パワーアップ弾
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;

    // 弾を撃つかどうか
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
        // アニメーターコンポーネンネントを取得
        animator = GetComponent<Animator>();

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.y > Player.transform.position.y)
        {
            //Vector2 w = Player.transform.position;
            //GetComponent<NavMeshAgent2D>().destination = w;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * -0.01f);
        }*/
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
            //DivEnemy.transform.position = new Vector3(transform.position.x + Random.Range(-200, 200), transform.position.y + Random.Range(-30, 0),transform.position.z);
        }
        
    }

    public void Track(Vector2 w)
    {
        if(transform.position.y > Player.transform.position.y)
        {
            //Vector2 w = Player.transform.position;
            //GetComponent<NavMeshAgent2D>().destination = w;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * -0.01f);
        }
        
    }
}
