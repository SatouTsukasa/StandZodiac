using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // エディタ、実機で処理を分ける

        if (Application.isEditor)
        {
            // エディタで実行中
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("クリックした瞬間");
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("離した瞬間");
            }

            if (Input.GetMouseButton(0))
            {
                Debug.Log("クリックしっぱなし");
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

}
