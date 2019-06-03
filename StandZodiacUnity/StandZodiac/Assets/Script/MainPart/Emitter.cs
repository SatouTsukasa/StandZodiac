using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;
using UnityEngine.SceneManagement;


public class Emitter : MonoBehaviour
{
    //Waveプレハブの格納
    public GameObject[] waves;



    //現在のWave
    private int currentWave;

    string Scenename;

    IEnumerator Start()
    {
        Scenename = SceneManager.GetActiveScene().name;
        //Waveが存在しなければコルーチンを終了する
        if (waves.Length == 0)
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
                    Debug.Log("asdfghcvx");
                    Invoke("MoveJoker", 5);
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

    void MoveJoker()
    {

        if (Scenename == "Stage1") SceneManager.LoadScene("BATTLE_1");
        if (Scenename == "Stage2") SceneManager.LoadScene("BATTLE_2");
        if (Scenename == "Stage3") SceneManager.LoadScene("BATTLE_3");
        if (Scenename == "Stage1_Boss") SceneManager.LoadScene("BATTLE_1_WIN");
        if (Scenename == "Stage2_Boss") SceneManager.LoadScene("BATTLE_2_WIN");
        if (Scenename == "Stage3_Boss") SceneManager.LoadScene("BATTLE_3_WIN");
    }
}
