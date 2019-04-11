
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //ヒット�EインチE
    public int hp = 1;

    public float speed;

    // Spaceshipコンポ�EネンチE
    Spaceship spaceship;

    //PowerUpItemプレハブの格紁E
    public GameObject[] PItem;

    //アイチE��の種顁E
    private int ItemNumber;

    //アイチE��を落とす確玁E
    private int ItemPar;

    Vector2 w;

    IEnumerator Start()
    {
        // Spaceshipコンポ�Eネントを取征E
        spaceship = GetComponent<Spaceship>();



        /*if (LayerMask.LayerToName(gameObject.layer) == "DivEnemy")
        {
            Debug.Log("pppppppppppppppppp");
            transform.position = new Vector2(transform.position.x + Random.Range(-100, 100), transform.position.y + Random.Range(-30, 0));
        }*/

        // ローカル座標�EY軸のマイナス方向に移動すめE
        
        
            Move(transform.up * -speed);
        

        // canShotがfalseの場合、ここでコルーチンを終亁E��せる
        if (spaceship.canShot == false)
        {
            yield break;
        }

        

        while (true)
        {

            // 
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

            // shotDelay
            yield return new WaitForSeconds(spaceship.shotDelay);


        }

        
    }

    /*// Start is called before the first frame update
    void Start()
    {
        // Spaceshipコンポ�Eネントを取征E
        spaceship = GetComponent<Spaceship>();

        // ローカル座標�EY軸のマイナス方向に移動すめE
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

    // 機体�E移勁E
    public void Move(Vector2 direction)
    {
        
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取征E
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外�E時�E何も行わなぁE
        //if (layerName != "Bullet(Player)") return;
        if (layerName == "Bullet(Player)") { 

            // PlayerBulletのTransformを取征E
            Transform playerBulletTransform = c.transform.parent;

            // Bulletコンポ�Eネントを取征E
            Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

            // ヒット�Eイントを減らぁE
            hp = hp - bullet.power;

            // 弾の削除
            Destroy(c.gameObject);

        }

        //爁E��に当たったら(誘�E)
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
                // PowerItemを作�Eする
                GameObject item = (GameObject)Instantiate(PItem[ItemNumber], transform.position, Quaternion.identity);
            }

            // 爁E��
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

