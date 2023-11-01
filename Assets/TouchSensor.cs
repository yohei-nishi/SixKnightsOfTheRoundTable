using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSensor : MonoBehaviour
{
    // カード選択状態。
    public enum State { idle, selected, disable}
    public State state = State.idle;

    // レーンのオブジェクト
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    public GameObject lane5;

    // LaneClickControllerの器
    public LaneClickControler script1;
    public LaneClickControler script2;
    public LaneClickControler script3;
    public LaneClickControler script4;
    public LaneClickControler script5;

    private void Start()
    {
        this.lane1 = GameObject.Find("BattleLane1");
        this.lane2 = GameObject.Find("BattleLane2");
        this.lane3 = GameObject.Find("BattleLane3");
        this.lane4 = GameObject.Find("BattleLane4");
        this.lane5 = GameObject.Find("BattleLane5");

        this.script1 = lane1.GetComponent<LaneClickControler>();
        this.script2 = lane2.GetComponent<LaneClickControler>();
        this.script3 = lane3.GetComponent<LaneClickControler>();
        this.script4 = lane4.GetComponent<LaneClickControler>();
        this.script5 = lane5.GetComponent<LaneClickControler>();

        // EventTriggerを設定する
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        // 実行したい処理をListに追加
        entry.callback.AddListener((evenDate) => { OnClickCharactor(); });
        entry.callback.AddListener((evenDate) => { script1.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script2.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script3.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script4.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script5.OnClickCharactorCard(); });
        trigger.triggers.Add(entry);
    }

    // キャラがクリックされたときに実行される処理
    public void OnClickCharactor()
    {
        // キャラが待機状態なら
        if(state == State.idle)
        {
            Debug.Log("選択状態にした");
            state = State.selected;

            // このキャラを光らせる
            // 他のキャラが選択状態なら待機に戻す
        }
    }

    // レーンがクリックされたときに実行される処理
    public void OnClickLane()
    {
        // キャラが選択状態なら
        if (state == State.selected)
        {
            Debug.Log("選択不可にした");
            state = State.disable;

            // 【予定】発光を元に戻し、カードを移動する
        }
    }

    // 【予定】自身が選択状態のとき、他のカードが選択状態になったらこのカードを待機状態に戻す。

    // 【予定】ターン終了時、Statusをidleにしてカードの位置を戻す。
}
