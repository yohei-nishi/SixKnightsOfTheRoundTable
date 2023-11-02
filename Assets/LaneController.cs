using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;

public class LaneController : MonoBehaviour
{
    // レーンの状態｛使用可能、発光、使用済み｝
    public enum LaneState { available, lightUp, used }
    public LaneState laneState = LaneState.available;

    // GameControllerのオブジェクト
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        // GameControllerのオブジェクトを取得
        gameController = GameObject.Find("GameController");

        // EventTriggerを設定
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // ラムダ式の右辺｛｝内に実行したい関数を入れる
        entry.callback.AddListener((evenData) => { OnClickThis(); });
        entry.callback.AddListener((evenData) => { gameController.GetComponent<GameController>().OnClickLane(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // このレーンがクリックされたとき
    public void OnClickThis()
    {
        if(laneState == LaneState.lightUp)
        {
            // 発光状態なら使用済みにする
            Debug.Log("使用済みにした");
            laneState= LaneState.used;
        }

    }
}
