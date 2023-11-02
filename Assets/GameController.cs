using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharactorController;

public class GameController : MonoBehaviour
{

    // キャラとレーンのオブジェクト
    public GameObject charactor1;
    public GameObject charactor2;
    public GameObject charactor3;
    public GameObject charactor4;
    public GameObject charactor5;
    public GameObject charactor6;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    public GameObject lane5;
    public GameObject lane6;
    public GameObject lane7;
    public GameObject lane8;
    public GameObject lane9;
    public GameObject lane10;

    // キャラとレーンのスクリプト
    public CharactorController scriptCC1;
    public CharactorController scriptCC2;
    public CharactorController scriptCC3;
    public CharactorController scriptCC4;
    public CharactorController scriptCC5;
    public CharactorController scriptCC6;
    public LaneController      scriptLC1;
    public LaneController      scriptLC2;
    public LaneController      scriptLC3;
    public LaneController      scriptLC4;
    public LaneController      scriptLC5;

    // キャラとレーンの選択の型

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
        this.lane1      = GameObject.Find("BattleLane1");
        this.lane2      = GameObject.Find("BattleLane2");
        this.lane3      = GameObject.Find("BattleLane3");
        this.lane4      = GameObject.Find("BattleLane4");
        this.lane5      = GameObject.Find("BattleLane5");
        this.lane6      = GameObject.Find("BattleLane6");
        this.lane7      = GameObject.Find("BattleLane7");
        this.lane8      = GameObject.Find("BattleLane8");
        this.lane9      = GameObject.Find("BattleLane9");
        this.lane10     = GameObject.Find("BattleLane10");

        // スクリプトを取得
        scriptCC1 = charactor1.GetComponent<CharactorController>();
        scriptCC2 = charactor2.GetComponent<CharactorController>();
        scriptCC3 = charactor3.GetComponent<CharactorController>();
        scriptCC4 = charactor4.GetComponent<CharactorController>();
        scriptCC5 = charactor5.GetComponent<CharactorController>();
        scriptCC6 = charactor6.GetComponent<CharactorController>();
        scriptLC1 = lane1.GetComponent<LaneController>();
        scriptLC2 = lane2.GetComponent<LaneController>();
        scriptLC3 = lane3.GetComponent<LaneController>();
        scriptLC4 = lane4.GetComponent<LaneController>();
        scriptLC5 = lane5.GetComponent<LaneController>();

        // 各キャラとレーンのStateを初期化

    }

    // Update is called once per frame
    void Update()
    {
        // 各キャラとレーンのStateを監視
        
    }

    // カードをクリックしたときの処理
    public void OnClickChara()
    {
        // 選択状態のキャラを待機に戻す
        if (scriptCC1.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ1を待機状態に戻した");
            scriptCC1.charactorState = CharactorState.idle;
        }
        if (scriptCC2.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ2を待機状態に戻した");
            scriptCC2.charactorState = CharactorState.idle;
        }
        if (scriptCC3.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ3を待機状態に戻した");
            scriptCC3.charactorState = CharactorState.idle;
        }
        if (scriptCC4.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ4を待機状態に戻した");
            scriptCC4.charactorState = CharactorState.idle;
        }
        if (scriptCC5.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ5を待機状態に戻した");
            scriptCC5.charactorState = CharactorState.idle;
        }
        if (scriptCC6.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ6を待機状態に戻した");
            scriptCC6.charactorState = CharactorState.idle;
        }
    }

    // 
    public void OnClickChara2()
    {
        // 待機状態のキャラクターがいればレーンを発光状態に、
        if (scriptCC1.charactorState == CharactorState.selected || 
            scriptCC2.charactorState == CharactorState.selected ||
            scriptCC3.charactorState == CharactorState.selected ||
            scriptCC4.charactorState == CharactorState.selected ||
            scriptCC5.charactorState == CharactorState.selected ||
            scriptCC6.charactorState == CharactorState.selected   )
        {
            if (scriptLC1.laneState == LaneController.LaneState.available)
            {
                Debug.Log("レーン1を発光状態にした");
                scriptLC1.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC2.laneState == LaneController.LaneState.available)
            {
                Debug.Log("レーン2を発光状態にした");
                scriptLC2.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC3.laneState == LaneController.LaneState.available)
            {
                Debug.Log("レーン3を発光状態にした");
                scriptLC3.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC4.laneState == LaneController.LaneState.available)
            {
                Debug.Log("レーン4を発光状態にした");
                scriptLC4.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC5.laneState == LaneController.LaneState.available)
            {
                Debug.Log("レーン5を発光状態にした");
                scriptLC5.laneState = LaneController.LaneState.lightUp;
            }
        }
        // いなければレーンを使用可能状態に
        else
        {
            if (scriptLC1.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("レーン1を使用可能にした");
                scriptLC1.laneState = LaneController.LaneState.available;
            }
            if (scriptLC2.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("レーン2を使用可能にした");
                scriptLC2.laneState = LaneController.LaneState.available;
            }
            if (scriptLC3.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("レーン3使用可能にした");
                scriptLC3.laneState = LaneController.LaneState.available;
            }
            if (scriptLC4.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("レーン4を使用可能にした");
                scriptLC4.laneState = LaneController.LaneState.available;
            }
            if (scriptLC5.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("レーン5を使用可能にした");
                scriptLC5.laneState = LaneController.LaneState.available;
            }
        }
    }

    // レーンをクリックしたときの処理
    public void OnClickLane()
    {
        if (scriptCC1.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ1を選択不可にした");
            scriptCC1.charactorState = CharactorState.disable;
        }
        if (scriptCC2.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ2を選択不可にした");
            scriptCC2.charactorState = CharactorState.disable;
        }
        if (scriptCC3.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ3を選択不可にした");
            scriptCC3.charactorState = CharactorState.disable;
        }
        if (scriptCC4.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ4を選択不可にした");
            scriptCC4.charactorState = CharactorState.disable;
        }
        if (scriptCC5.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ5を選択不可にした");
            scriptCC5.charactorState = CharactorState.disable;
        }
        if (scriptCC6.charactorState == CharactorState.selected)
        {
            Debug.Log("キャラ6を選択不可にした");
            scriptCC6.charactorState = CharactorState.disable;
        }
        if (scriptLC1.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("レーン1を使用可能に戻した");
            scriptLC1.laneState = LaneController.LaneState.available;
        }
        if (scriptLC2.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("レーン2を使用可能に戻した");
            scriptLC2.laneState = LaneController.LaneState.available;
        }
        if (scriptLC3.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("レーン3を使用可能に戻した");
            scriptLC3.laneState = LaneController.LaneState.available;
        }
        if (scriptLC4.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("レーン4を使用可能に戻した");
            scriptLC4.laneState = LaneController.LaneState.available;
        }
        if (scriptLC5.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("レーン5を使用可能に戻した");
            scriptLC5.laneState = LaneController.LaneState.available;
        }
    }
}
