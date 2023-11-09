using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;
using DG.Tweening;

public class LaneController : MonoBehaviour
{
    // レーンの状態｛使用可能、発光、コマンド選択、使用済み｝
    public enum LaneState { available, lightUp, commandSelect,used }
    public LaneState laneState = LaneState.available;

    // レーンのコマンド
    public enum Command { empty, attack, charge, guard, full}
    public Command command = Command.empty;

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
        entry.callback.AddListener((evenData) => { OnClickThis(); }); // クリックされたlaneだけをlirhtUPからcommandSelectにする
        entry.callback.AddListener((evenData => { }));　// UIボタンをクリックされたレーン上に出現させる。
        entry.callback.AddListener((evenData) => { gameController.GetComponent<GameController>().OnClickLane(); }); // 選択状態のキャラを使用不可にして、残りのレーンをavailableに戻す
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
            case LaneState.commandSelect:
                this.renderComponent.material.DOColor(Color.yellow, 0.2f);
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
            Debug.Log("コマンド選択状態にした");
            laneState= LaneState.commandSelect;
        }
    }
}
