?��using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    // Spaceshipコンポ�?�ネン�?
    Spaceship spaceship;

    public float speed = 0;

    Vector3 cashPosition;

    private Vector3 playerPos;
    private Vector3 mousePos;

    public AudioClip ShotSound;
    public AudioClip ItemAcquisition;

    //パワーア�?プbool関数

    public bool PU2;
    public bool PU3;
    public bool PU4;
    public bool PU5;
    // Start is called before the first frame update
    // Startメソ�?ドをコルーチンとして呼び出�?
    IEnumerator Start()
    {
        // Spaceshipコンポ�?�ネントを取�?
        spaceship = GetComponent<Spaceship>();
        while (true)
        {
            // 弾を�?�レイヤーと同じ位置/角度で作�??
            spaceship.Shot(transform);
            if(PU2 == true)
            {
                spaceship.ShotPU(transform, PU2, PU3, PU4, PU5);
            }

            //,PU1,PU2,PU3,PU4

            // ショ�?ト音を鳴らす
            //GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().PlayOneShot(ShotSound);

            // shotDelay秒�?つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //画面外判�?
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Debug.Log("画面�?");
        }

        // エ�?ィタ、実機で処�?を�??ける

        if (Application.isEditor)
        {
            // エ�?ィタで実行中
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("クリ�?クした瞬�?");
                /*Vector3 position = Input.mousePosition;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", position.x, "y", position.y, "time", 1.0f));*/

                //playerPos = this.transform.position;
                //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Move();
            }

            if (Input.GetMouseButtonUp(0))
            {
                playerPos = Vector3.zero;
                mousePos = Vector3.zero;
                Debug.Log("離した瞬�?");     
            }

            if (Input.GetMouseButton(0))
            {
                /*Vector3 position = Input.mousePosition;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", position.x, "y", position.y, "time", 1.0f));*/
                Debug.Log("クリ�?クしっぱな�?");
                
                //Vector3 prePos = this.transform.position;
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

                Move();

                //タ�?チ対応デバイス向け�?1本目の�?にのみ反�?
                if (Input.touchSupported)
                {
                    diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
                }

                diff.z = 0.0f;
                //this.transform.position = playerPos + diff;
                this.transform.position = Vector3.MoveTowards(transform.position, playerPos + diff, speed);
                
               
            }
            
        }
        else
        {
            // 実機で実行中
            // タ�?チされて�?るかチェ�?ク
            if (Input.touchCount > 0)
            {
                // タ�?チ情報の取�?
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("押した瞬�?");
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("離した瞬�?");
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("押しっぱな�?");
                }
            }
        }

        Move();
    }

    void Move()
    {
        // 画面左下�?�ワールド座標をビューポ�?�トから取�?
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.11f));

        // 画面右上�?�ワールド座標をビューポ�?�トから取�?
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.8f));

        // プレイヤーの座標を取�?
        Vector2 pos = transform.position;

        Vector3 prePos = this.transform.position;
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

        // プレイヤーの位置が画面�?に収まるよ�?に制限をかけ�?
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値を�?�レイヤーの位置とする
        transform.position = pos;
    }

    public void OnMouseDrag()
    {
        Vector3 objectPointInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 mousePointInScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPointInScreen.z);
        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);

        //mousePointInWorld.z = this.transform.position.z;
        mousePointInWorld.z = 0;

        cashPosition = mousePointInWorld;
        this.transform.position = new Vector3(cashPosition.x, cashPosition.y, cashPosition.z);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // レイヤー名を取�?
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時�?�弾を削除
        if (layerName == "Bullet(Enemy)")
        {
            // 弾の削除
            Destroy(col.gameObject);
        }

        // レイヤー名がBullet (Enemy)また�?�Enemyの場合�?��?発
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            // �?発する
            spaceship.Explosion();

            // プレイヤーを削除
            Destroy(gameObject);
        }

        if(layerName == "Item")
        {
            GetComponent<AudioSource>().PlayOneShot(ItemAcquisition);
            //Debug.Log("iiiiiiiii");
            //Destroy(col.gameObject);
        }
    }

}

