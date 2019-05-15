using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    //Waveプレハブの格納
    public GameObject[] waves;

    //ノーマルかボスか
    public bool Boss;

    //現在のWave
    private int currentWave;

    IEnumerator Start()
    {
        //Waveが存在しなければコルーチンを終了する
        if(waves.Length == 0)
        {
            yield break;
        }

        while (true)
        {

            // Waveを作成する
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
                //Debug.Log(currentWave);
            }

            // Waveの削除
            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                if(Boss == true)
                {
                    Debug.Log("qwedfgtghuj");
                    currentWave = 0;
                }

                yield break;
            }

        }
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
