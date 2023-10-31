using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaneClickControler : MonoBehaviour
{

    // レーンの状態
    public enum State { available, lightUp, used }
    public State state = State.available;

    // オブジェクトの器
    public GameObject charactor1;
    public GameObject charactor2;
    public GameObject charactor3;
    public GameObject charactor4;
    public GameObject charactor5;
    public GameObject charactor6;

    // スクリプトの器
    public TouchSensor script1;
    public TouchSensor script2;
    public TouchSensor script3;
    public TouchSensor script4;
    public TouchSensor script5;
    public TouchSensor script6;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトを取得
        this.charactor1 = GameObject.Find("術師　味方");
        this.charactor2 = GameObject.Find("戦士　味方");
        this.charactor3 = GameObject.Find("騎士　味方");
        this.charactor4 = GameObject.Find("狩人　味方");
        this.charactor5 = GameObject.Find("戦車　味方");
        this.charactor6 = GameObject.Find("隠者　味方");

        // スクリプトを取得
        script1 = charactor1.GetComponent<TouchSensor>();
        script2 = charactor2.GetComponent<TouchSensor>();
        script3 = charactor3.GetComponent<TouchSensor>();
        script4 = charactor4.GetComponent<TouchSensor>();
        script5 = charactor5.GetComponent<TouchSensor>();
        script6 = charactor6.GetComponent<TouchSensor>();


        // EventTriggerを設定する
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        // リストに加えたい関数をラムダ式の右辺に入れる
        entry.callback.AddListener((evenData) => { OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script1.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script2.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script3.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script4.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script5.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script6.OnClickLane(); });
        trigger.triggers.Add(entry);
    }

    // レーンがクリックされたときの処理
    public void OnClickLane()
    {
        // レーンが発光状態なら
        if (state == State.lightUp)
        {
            Debug.Log("レーンが選択された");
            state = State.used;
        }
    }

    // カードがクリックされたとき
    public void OnClickCharactorCard()
    {
        // 使用可能状態なら
        if (state == State.available)
        {
            Debug.Log("レーンは発光状態になる");
            state = State.lightUp;
        }
    }
}
