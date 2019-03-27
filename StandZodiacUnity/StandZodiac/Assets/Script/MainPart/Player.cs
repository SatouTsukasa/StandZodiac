using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    // Spaceshipコンポーネント
    Spaceship spaceship;

    public float speed = 0;

    Vector3 cashPosition;

    // PlayerBulletプレハブ
    //public GameObject bullet;

    //public GameObject player;

    private Vector3 playerPos;
    private Vector3 mousePos;
    // Start is called before the first frame update

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            spaceship.Shot(transform);

            // ショット音を鳴らす
            GetComponent<AudioSource>().Play();

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //画面外判定
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Debug.Log("画面外");
        }

        // エディタ、実機で処理を分ける

        if (Application.isEditor)
        {
            // エディタで実行中
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("クリックした瞬間");
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
                Debug.Log("離した瞬間");     
            }

            if (Input.GetMouseButton(0))
            {
                /*Vector3 position = Input.mousePosition;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", position.x, "y", position.y, "time", 1.0f));*/
                Debug.Log("クリックしっぱなし");
                
                //Vector3 prePos = this.transform.position;
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

                Move();

                //タッチ対応デバイス向け、1本目の指にのみ反応
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
            // タッチされているかチェック
            if (Input.touchCount > 0)
            {
                // タッチ情報の取得
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("押した瞬間");
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("離した瞬間");
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("押しっぱなし");
                }
            }
        }

        Move();
    }

    void Move()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.11f));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.8f));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        Vector3 prePos = this.transform.position;
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
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
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet(Enemy)")
        {
            // 弾の削除
            Destroy(col.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            // 爆発する
            spaceship.Explosion();

            // プレイヤーを削除
            Destroy(gameObject);
        }
    }

}
