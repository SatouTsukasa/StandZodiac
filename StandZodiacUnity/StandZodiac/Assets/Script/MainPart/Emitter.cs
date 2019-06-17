using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;
using UnityEngine.SceneManagement;


public class Emitter : MonoBehaviour
{
    //Waveプレハブの格納
    public GameObject[] waves;

    BattleStartManager BTM;
    int btm;

    //現在のWave
    private int currentWave;

    string Scenename;

    IEnumerator Start()
    {
        Scenename = SceneManager.GetActiveScene().name;
        BTM = GetComponent<BattleStartManager>();
        btm = BTM.BattleStatus;
        //Waveが存在しなければコルーチンを終了する
        if (waves.Length == 0)
        {
            yield break;
        }

        while(btm == BattleStartManager.BATTLE_START) { yield return null; }

        while (btm == BattleStartManager.BATTLE_PLAY)
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
                    //BTM.BattleStatus = BattleStartManager.BATTLE_END;
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
        btm = BTM.BattleStatus;
        //BTM =  GameObject.Find("Emitter").GetComponent<BattleStartManager>().BattleStatus;
        //Debug.Log(BTM.BattleStatus);
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
