?��using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //ヒット�?�イン�?
    public int hp = 1;

    public float speed;

    // Spaceshipコンポ�?�ネン�?
    Spaceship spaceship;

    //PowerUpItemプレハブの格�?
    public GameObject[] PItem;

    //アイ�?�?の種�?
    private int ItemNumber;

    //アイ�?�?を落とす確�?
    private int ItemPar;

    IEnumerator Start()
    {
        // Spaceshipコンポ�?�ネントを取�?
        spaceship = GetComponent<Spaceship>();

        

        // ローカル座標�?�Y軸のマイナス方向に移動す�?
        Move(transform.up * -speed);

        

        // canShotがfalseの場合、ここでコルーチンを終�?させ�?
        if (spaceship.canShot == false)
        {
            yield break;
        }

        

        while (true)
        {

            // 子要�?を�?�て取得す�?
            for (int i = 0; i < transform.childCount; i++)
            {

                Transform shotPosition = transform.GetChild(i);

                // ShotPositionの位置/角度で弾を撃つ
                spaceship.Shot(shotPosition);
            }

            // shotDelay秒�?つ
            yield return new WaitForSeconds(spaceship.shotDelay);


        }

        
    }

    /*// Start is called before the first frame update
    void Start()
    {
        // Spaceshipコンポ�?�ネントを取�?
        spaceship = GetComponent<Spaceship>();

        // ローカル座標�?�Y軸のマイナス方向に移動す�?
        spaceship.Move(transform.up * -1);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (spaceship.Tackle == true)
        {
            Vector2 v = new Vector3(0, speed * Time.deltaTime);
            transform.Translate(v);
            //spaceship.Compliance();
            //transform.position = Vector3.MoveTowards(spaceship.Player.transform.position, /*spaceship.Player.*/transform.position, speed);
            // ターゲ�?トとの座標間隔を取�?
            Vector3 diff = (spaceship.Player.transform.position - this.transform.position).normalized;
            // 回転させる　Quaternion.FromToRotation?��第1引数 から 第2引数 への回転をさせる?�?
            this.transform.rotation = Quaternion.FromToRotation(Vector3.left, diff);
            Debug.Log("ccc");

            //return;
        }

    }

    // 機体�?�移�?
    public void Move(Vector2 direction)
    {
        
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取�?
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外�?�時�?�何も行わな�?
        //if (layerName != "Bullet(Player)") return;
        if (layerName == "Bullet(Player)") { 

            // PlayerBulletのTransformを取�?
            Transform playerBulletTransform = c.transform.parent;

            // Bulletコンポ�?�ネントを取�?
            Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

            // ヒット�?�イントを減ら�?
            hp = hp - bullet.power;

            // 弾の削除
            Destroy(c.gameObject);

        }

        //�?発に当たったら(誘�??)
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

            Debug.Log(ItemPar);
            //Debug.Log("---------------" + PItem[0]);

            if(ItemPar == 0)
            {
                // Waveを作�?�す�?
                GameObject item = (GameObject)Instantiate(PItem[ItemNumber], transform.position, Quaternion.identity);
            }

            // �?発
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

