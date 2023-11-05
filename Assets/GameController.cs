using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static CharactorController;

public class GameController : MonoBehaviour
{
    // キャラとレーンのオブジェクトを入れるリスト
    public GameObject[] charactor;
    public GameObject[] Lane;
    public CharactorController[] scriptC;
    public LaneController[] scriptL;
    
    // キャラをクリックしたとき、既に選択状態のキャラを待機状態に戻す処理
    public void OnClickChara()
    {
        foreach (var state in scriptC.Where(x => x.charactorState == CharactorState.selected))
        { 
            state.charactorState = CharactorController.CharactorState.idle;
            DOTween.Kill("Fade");
        }
    }

    // キャラをクリックしたとき、キャラの選択状態に応じてレーンの状態を変える処理
    public void OnClickChara2()
    {
        // 選択状態のキャラクターがいればレーンを発光状態に、
        if (scriptC.Any(state => state.charactorState == CharactorState.selected))
        {
            foreach(var state in scriptL.Where(x => x.laneState == LaneController.LaneState.available))
            {
                state.laneState = LaneController.LaneState.lightUp;
                Debug.Log("レーンを発光させた");

            }
        } 
        // いなければレーンを使用可能状態に
        else
        {
            foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.lightUp))
            {
                state.laneState = LaneController.LaneState.available;
                Debug.Log("レーンを使用可能に戻した");
            }
        }
    }

    // レーンをクリックしたときの処理
    public void OnClickLane()
    {
        foreach (var state in scriptC.Where(x => x.charactorState == CharactorState.selected))
        {
            state.charactorState = CharactorController.CharactorState.disable;
            DOTween.Kill("Fade");
            Debug.Log("キャラを選択不可にした");
        }
        // 使わなかったレーンをavalableに戻す
        foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.lightUp))
        {
            state.laneState = LaneController.LaneState.available;
            Debug.Log("レーンを使用可能に戻した");
        }
    }
}
