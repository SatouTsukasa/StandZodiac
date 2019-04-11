
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //繝偵ャ繝医・繧､繝ｳ繝・
    public int hp = 1;

    public float speed;

    // Spaceship繧ｳ繝ｳ繝昴・繝阪Φ繝・
    Spaceship spaceship;

    //PowerUpItem繝励Ξ繝上ヶ縺ｮ譬ｼ邏・
    public GameObject[] PItem;

    //繧｢繧､繝・Β縺ｮ遞ｮ鬘・
    private int ItemNumber;

    //繧｢繧､繝・Β繧定誠縺ｨ縺咏｢ｺ邇・
    private int ItemPar;

    Vector2 w;

    IEnumerator Start()
    {
        // Spaceship繧ｳ繝ｳ繝昴・繝阪Φ繝医ｒ蜿門ｾ・
        spaceship = GetComponent<Spaceship>();



        /*if (LayerMask.LayerToName(gameObject.layer) == "DivEnemy")
        {
            Debug.Log("pppppppppppppppppp");
            transform.position = new Vector2(transform.position.x + Random.Range(-100, 100), transform.position.y + Random.Range(-30, 0));
        }*/

        // 繝ｭ繝ｼ繧ｫ繝ｫ蠎ｧ讓吶・Y霆ｸ縺ｮ繝槭う繝翫せ譁ｹ蜷代↓遘ｻ蜍輔☆繧・
        
        
            Move(transform.up * -speed);
        

        // canShot縺掲alse縺ｮ蝣ｴ蜷医√％縺薙〒繧ｳ繝ｫ繝ｼ繝√Φ繧堤ｵゆｺ・＆縺帙ｋ
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
        // Spaceship繧ｳ繝ｳ繝昴・繝阪Φ繝医ｒ蜿門ｾ・
        spaceship = GetComponent<Spaceship>();

        // 繝ｭ繝ｼ繧ｫ繝ｫ蠎ｧ讓吶・Y霆ｸ縺ｮ繝槭う繝翫せ譁ｹ蜷代↓遘ｻ蜍輔☆繧・
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

    // 讖滉ｽ薙・遘ｻ蜍・
    public void Move(Vector2 direction)
    {
        
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // 繝ｬ繧､繝､繝ｼ蜷阪ｒ蜿門ｾ・
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // 繝ｬ繧､繝､繝ｼ蜷阪′Bullet (Player)莉･螟悶・譎ゅ・菴輔ｂ陦後ｏ縺ｪ縺・
        //if (layerName != "Bullet(Player)") return;
        if (layerName == "Bullet(Player)") { 

            // PlayerBullet縺ｮTransform繧貞叙蠕・
            Transform playerBulletTransform = c.transform.parent;

            // Bullet繧ｳ繝ｳ繝昴・繝阪Φ繝医ｒ蜿門ｾ・
            Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

            // 繝偵ャ繝医・繧､繝ｳ繝医ｒ貂帙ｉ縺・
            hp = hp - bullet.power;

            // 蠑ｾ縺ｮ蜑企勁
            Destroy(c.gameObject);

        }

        //辷・匱縺ｫ蠖薙◆縺｣縺溘ｉ(隱倡・)
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
                // PowerItem繧剃ｽ懈・縺吶ｋ
                GameObject item = (GameObject)Instantiate(PItem[ItemNumber], transform.position, Quaternion.identity);
            }

            // 辷・匱
            spaceship.Explosion();

            

            // 繧ｨ繝阪Α繝ｼ縺ｮ蜑企勁
            Destroy(gameObject);

            GetComponent<ScoreEnemyManager>().GetPoint();

        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
            
        }
    }

    private void OnDestroy()
    {
        GameObject Gauge = GameObject.Find("Gauge");
        Gauge.GetComponent<Gauge>().ADDgauge();
    }
}

