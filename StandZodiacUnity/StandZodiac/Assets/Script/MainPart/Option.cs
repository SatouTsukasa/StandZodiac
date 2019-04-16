using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Rigidbodyの速度を保存しておくクラス
/// </summary>
public class RigidbodyVelocity
{
    //velovityは速度やで
    //rigidbody.velocityは速度を即座に変更するときとかに使う。今回のポーズ画面とかFPSのジャンプ？で使うらしい。完成の法則完全に無視した動きになるからそこは把握しておくべき

    public Vector3 velocity;
    public Vector3 angularVeloccity;
    public RigidbodyVelocity(Rigidbody rigidbody)
    {

        velocity = rigidbody.velocity;

        //rigidbody.angularVelocityは角速度（回転速度かな）の話やで。rigiddbodyの角速度を代入
        angularVeloccity = rigidbody.angularVelocity;
    }
}

public class Option : MonoBehaviour
{

    /// <summary>
    /// 現在Pause中か？
    /// </summary>
    public bool pausing;

    /// <summary>
    /// 無視するGameObject
    /// </summary>
    public GameObject[] ignoreGameObjects;

    /// <summary>
    /// ポーズ状態が変更された瞬間を調べるため、前回のポーズ状況を記録しておく
    /// </summary>
    bool prevPausing;

    /// <summary>
    /// Rigidbodyのポーズ前の速度の配列
    /// </summary>
    /// おそらくRigidbodyVelocityクラスの変数が入ってる？
    RigidbodyVelocity[] rigidbodyVelocities;

    /// <summary>
    /// ポーズ中のRigidbodyの配列
    /// </summary>
    Rigidbody[] pausingRigidbodies;

    /// <summary>
    /// ポーズ中のMonoBehaviourの配列
    /// </summary>
    MonoBehaviour[] pausingMonoBehaviours;

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        // ポーズ状態が変更されていたら、Pause/Resumeを呼び出す。
        if (prevPausing != pausing)
        {
            if (pausing) Pause();
            else Resume();
            prevPausing = pausing;
        }
    }

    /// <summary>
    /// 中断
    /// </summary>
    void Pause()
    {
        // Rigidbodyの停止
        // 子要素から、スリープ中でなく、IgnoreGameObjectsに含まれていないRigidbodyを抽出
        Predicate<Rigidbody> rigidbodyPredicate =
            //Sleepingとはrigidbodyが一定の移動、回転速度を下回った時に急停止したと判断して止まる状態らしい。
            //rigidbodyがないものがスリープしたときにトランスフォームの位置調整の為に動いた場合起きない時があるみたいなので注意
            obj => !obj.IsSleeping() &&
            
            //Findとは配列の中身を条件に合ったものを探してその値を返すもの。また、先に見つかったものを返すため配列の左側が返される
            //FindAllの場合、条件に合ったすべての物を返す
            //FindLastの場合は後ろから一個だけ
            //Indexとは配列の添え字。1,2,3,4,5と並んでいた場合「0,1,2,3,4」と順番に配列の部屋番号が振ってある。その部屋番号がIndex
            //つまりFindIndexとはその部屋番号を返す。もし「2」が欲しかった場合、帰ってくる数字は「1」となる。因みに前から。後ろからならFindLastIndexを使う
            //Arrayは配列だぞ、と

                   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
        pausingRigidbodies = Array.FindAll(transform.GetComponentsInChildren<Rigidbody>(), rigidbodyPredicate);
        rigidbodyVelocities = new RigidbodyVelocity[pausingRigidbodies.Length];
        for (int i = 0; i < pausingRigidbodies.Length; i++)
        {
            // 速度、角速度も保存しておく
            rigidbodyVelocities[i] = new RigidbodyVelocity(pausingRigidbodies[i]);
            pausingRigidbodies[i].Sleep();
        }

        // MonoBehaviourの停止
        // 子要素から、有効かつこのインスタンスでないもの、IgnoreGameObjectsに含まれていないMonoBehaviourを抽出
        Predicate<MonoBehaviour> monoBehaviourPredicate =
            obj => obj.enabled &&
                   obj != this &&
                   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
        pausingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);
        foreach (var monoBehaviour in pausingMonoBehaviours)
        {
            monoBehaviour.enabled = false;
        }

    }

    /// <summary>
    /// 再開
    /// </summary>
    void Resume()
    {
        // Rigidbodyの再開
        for (int i = 0; i < pausingRigidbodies.Length; i++)
        {
            pausingRigidbodies[i].WakeUp();
            pausingRigidbodies[i].velocity = rigidbodyVelocities[i].velocity;
            pausingRigidbodies[i].angularVelocity = rigidbodyVelocities[i].angularVeloccity;
        }

        // MonoBehaviourの再開
        foreach (var monoBehaviour in pausingMonoBehaviours)
        {
            monoBehaviour.enabled = true;
        }
    }
}