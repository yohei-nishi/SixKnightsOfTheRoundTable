using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;
using DG.Tweening;

public class LaneController : MonoBehaviour
{
    // レーンの状態｛使用可能、発光、使用済み｝
    public enum LaneState { available, lightUp, used }
    public LaneState laneState = LaneState.available;

    // Inspectorで見えるようにRenderの変数を作る
    [SerializeField]
    Renderer renderComponent;

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
        // 状態ごとに色を変える
        switch (laneState)
        { 
            case LaneState.available:
                this.renderComponent.material.DOColor(Color.blue, 0.2f);
                break;
            case LaneState.lightUp:
                this.renderComponent.material.DOColor(Color.red, 0.2f);
                break;
            case LaneState.used:
                this.renderComponent.material.DOColor(Color.green, 0.2f);
                break;
        }
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
