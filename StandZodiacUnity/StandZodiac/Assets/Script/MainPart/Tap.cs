using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour
{
    Vector3 BeginPosition;

    const float BUTTON_MAX_RANGE = 100f;
    public GameObject ButtonObj;
    public GameObject ButtonBackObj;
    RectTransform btnObjRect;
    RectTransform btnBackObjRect;

    Vector2 tapStartPos;
    Vector2 nowTapPos;

    bool inside;

   public Vector2 outPutPos; // 最大1 基本0 最小-1

    // Start is called before the first frame update
    void Start()
    {
        outPutPos = Vector2.zero;

        //this.gameObject.SetActive(false);
        ButtonObj.SetActive(false);
        ButtonBackObj.SetActive(false);
        btnObjRect = ButtonObj.GetComponent<RectTransform>();
        btnBackObjRect = ButtonBackObj.GetComponent<RectTransform>();

        inside = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == true)
        {

            
            if (Input.GetMouseButton(0))
            {
                // 初回タップ
                if (Input.GetMouseButtonDown(0))
                {
                    tapStartPos = Input.mousePosition;
                    //画面範囲内のみ反応
                    if (tapStartPos.y >= 1140 || tapStartPos.y <= 100) inside = false;
                    else inside = true;
                    
                    if(inside == true)
                    {
                        // 画像の表示切替と座標設定
                        ButtonObj.SetActive(true);
                        ButtonBackObj.SetActive(true);
                        btnObjRect.anchoredPosition = tapStartPos;
                        btnBackObjRect.anchoredPosition = tapStartPos;
                    }
                    
                }


                // 画像の座標設定と範囲制御
                nowTapPos = Input.mousePosition;

                if (Vector2.Distance(tapStartPos, nowTapPos) < BUTTON_MAX_RANGE)
                {
                    // ボタンの移動処理
                    btnObjRect.anchoredPosition = new Vector2(nowTapPos.x, nowTapPos.y);
                }
                else
                {
                    // ボタンの移動処理
                    // tapStartPosから見たnowTapPosへの角度を計算する
                    Vector2 dif = nowTapPos - tapStartPos;
                    float radian = Mathf.Atan2(dif.y, dif.x);
                    float rxMax = Mathf.Cos(radian) * BUTTON_MAX_RANGE;
                    float ryMax = Mathf.Sin(radian) * BUTTON_MAX_RANGE;
                    btnObjRect.anchoredPosition = new Vector2(rxMax + tapStartPos.x, ryMax + tapStartPos.y);
                }

                // 出力する値の設定
                Vector2 diff = btnObjRect.anchoredPosition - tapStartPos;
                outPutPos = new Vector2(diff.x / BUTTON_MAX_RANGE, diff.y / BUTTON_MAX_RANGE);



            }
            else
            {
                outPutPos = Vector2.zero;
                // 画像の表示切替と座標設定
                ButtonObj.SetActive(false);
                ButtonBackObj.SetActive(false);
            }

        }
        else
        {
            ButtonObj.SetActive(false);
            ButtonBackObj.SetActive(false);
        }

        //this.BeginPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        //this.gameObject.SetActive(true);

        /*
        //var item = Instantiate(BC);
        //item.transform.position = Input.mousePosition;
        var canvas = this.GetComponent<Canvas>();
        var canvasRect = canvas.GetComponent<RectTransform>();

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out localPoint);

        var item = Instantiate(BC);
        item.transform.SetParent(this.transform);
        item.GetComponent<RectTransform>().anchoredPosition = localPoint;

        /*var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
        Debug.Log(transform.position);*/

    }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    Debug.Log("zzzzzzzzzzzz");
        //    this.gameObject.SetActive(false);
        //}
        //if (Input.GetMouseButton(0))
        //{

        //}
    //}
}
