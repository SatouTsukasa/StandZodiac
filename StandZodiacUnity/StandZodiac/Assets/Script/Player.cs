using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // PlayerBulletプレハブ
    public GameObject bullet;

    //public GameObject player;

    private Vector3 playerPos;
    private Vector3 mousePos;
    // Start is called before the first frame update

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(0.05f);
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

                playerPos = this.transform.position;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

                Vector3 prePos = this.transform.position;
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

                //タッチ対応デバイス向け、1本目の指にのみ反応
                if (Input.touchSupported)
                {
                    diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
                }

                diff.z = 0.0f;
                this.transform.position = playerPos + diff;
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
    }

    private void FixedUpdate()
    {
        
    }

}
