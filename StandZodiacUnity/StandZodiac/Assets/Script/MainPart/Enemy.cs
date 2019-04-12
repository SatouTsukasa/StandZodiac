using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //ヒットポイント
    public int hp = 1;

    public float speed;

    // Spaceshipコンポーネント
    Spaceship spaceship;

    //PowerUpItemプレハブの格納
    public GameObject[] PItem;

    //アイテムの種類
    private int ItemNumber;

    //アイテムを落とす確率
    private int ItemPar;

    Vector2 w;

    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();



        /*if (LayerMask.LayerToName(gameObject.layer) == "DivEnemy")
        {
            Debug.Log("pppppppppppppppppp");
            this.transform.position = Vector3.MoveTowards(transform.position,
            new Vector2(transform.position.x + Random.Range(-200, 200), transform.position.y + Random.Range(-30, 0)), 1f);
        }

        // ローカル座標のY軸のマイナス方向に移動する
        Move(transform.up * -speed);

        // ローカル座標��EY軸のマイナス方向に移動すめE


            Move(transform.up * -speed);


        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (spaceship.canShot == false)
        {
            yield break;
        }



        while (true)
        {

            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++)
            {

                Transform shotPosition = transform.GetChild(i);

                // ShotPosition
                spaceship.Shot(shotPosition);
            }
            if (spaceship.Tackle == true)
            {
                //w = spaceship.Player.transform.position;

                //spaceship.Track(w);
                if (transform.position.y > spaceship.Player.transform.position.y)
                {
                    Debug.Log("ssssssssssssssssss");
                    transform.position = Vector3.MoveTowards(transform.position,
                        spaceship.Player.transform.position, speed * Time.deltaTime);
                }


            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);


        }


    }

    /*// Start is called before the first frame update
    void Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // ローカル座標のY軸のマイナス方向に移動する
        spaceship.Move(transform.up * -1);
    }*/

    // Update is called once per frame
    /*void Update()
    {

        if (spaceship.Tackle == true)
        {
            //w = spaceship.Player.transform.position;

            //spaceship.Track(w);
            if(transform.position.y > spaceship.Player.transform.position.y)
            {
                Debug.Log("ssssssssssssssssss");
                transform.position = Vector3.MoveTowards(transform.position,
                    spaceship.Player.transform.position, speed * 0.8f * Time.deltaTime);
            }
            else
            {
                Move(transform.up * -speed);
            }

        }


    }*/

    // 機体の移動
    public void Move(Vector2 direction)
    {

        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        //if (layerName != "Bullet(Player)") return;
        if (layerName == "Bullet(Player)") {

            // PlayerBulletのTransformを取得
            Transform playerBulletTransform = c.transform.parent;

            // Bulletコンポーネントを取得
            Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

            // ヒットポイントを減らす
            hp = hp - bullet.power;

            // 弾の削除
            Destroy(c.gameObject);

        }

        //爆発に当たったら(誘爆)
        if(layerName == "Explosion")
        {
            Transform explosionTransform = c.transform;

            Explosion explosion = explosionTransform.GetComponent<Explosion>();

            hp -= explosion.power;

            Debug.Log("ddd");
        }

        if (hp <= 0) {

            ItemPar = Random.Range(0, 10);
            ItemNumber = Random.Range(0, PItem.Length);

            //Debug.Log(ItemPar);
            //Debug.Log("---------------" + PItem[0]);

            if(spaceship.div == true)
            {
                spaceship.Division();
            }

            if(ItemPar == 0)
            {
                // PowerItemを作成する
                GameObject item = (GameObject)Instantiate(PItem[ItemNumber], transform.position, Quaternion.identity);
            }

            // 爆発
            spaceship.Explosion();



            // エネミーの削除
            Destroy(gameObject);

            GetComponent<ScoreEnemyManager>().GetPoint();

        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");

        }
    }
}
