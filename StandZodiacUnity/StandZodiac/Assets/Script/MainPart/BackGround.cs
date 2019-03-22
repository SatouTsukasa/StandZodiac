using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // スクロールするスピード
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 時間によってYの値が0から770に変化していく。770になったら0に戻り、繰り返す。
        float y = Mathf.Repeat(Time.time * speed, 770);

        // Yの値がずれていくオフセットを作成
        //Vector2 offset = new Vector2(0, y);

        // マテリアルにオフセットを設定する
        //GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
