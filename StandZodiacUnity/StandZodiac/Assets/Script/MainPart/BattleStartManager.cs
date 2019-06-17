using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartManager : MonoBehaviour
{
    [System.NonSerialized]
    public int BattleStatus;

    [System.NonSerialized]
    public const int BATTLE_START = 0;
    [System.NonSerialized]
    public const int BATTLE_PLAY = 1;
    [System.NonSerialized]
    public const int BATTLE_END = 2;

    float timer;
    public float limit;

    // Start is called before the first frame update
    void Start()
    {
        BattleStatus = BATTLE_START;

        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(BattleStatus);
        switch (BattleStatus)
        {
            case BATTLE_START:
                timer += Time.deltaTime;
                if(timer > limit)
                {
                    BattleStatus = BATTLE_PLAY;
                    timer = 0;
                }
                break;

            case BATTLE_PLAY:
                break;

            case BATTLE_END:
                break;

            default:
                break;
        }
    }
}
