using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static CharactorController;

public class GameController : MonoBehaviour
{
    // キャラとレーンのオブジェクトとスクリプトを入れるリスト
    public List<GameObject> charactor;
    public List<GameObject> Lane;
    public List<CharactorController> scriptC;
    public List<LaneController> scriptL;
    public List<Transform> laneTransform;

    // コマンド選択状態のレーンがあるか否か（キャラが選択状態になれるかの条件に使用）
    public bool isAnyLaneCS;

    // コマンド選択状態のレーン
    public GameObject laneCS;

    // コマンド選択状態のレーンの座標
    public Transform laneCsTransfom;

    // canvasと生成したいボタンの
    [SerializeField] List<GameObject> commadButton;

    // Canvasの座標
    [SerializeField] RectTransform canvasRect;
    
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
        // 選択状態のキャラを選択不可にする
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
        // コマンド選択状態のレーンがあれば
        if (scriptL.Any(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            // FindIndexでコマンド選択状態のスクリプトのインデックスを取得し、対応するトランスフォームをインデックスで指定し取得。
            var index = scriptL.FindIndex(x => x.laneState == LaneController.LaneState.commandSelect);
            laneCsTransfom = laneTransform[index];

            // UIボタンをアクティブにする
            foreach(var active in commadButton)
            { active.SetActive(true); }
        }
    }

    // Attackボタンを押したときの処理
    public void OnClickAttack()
    {
        // コマンド選択状態のレーンを探し、コマンド状態をAttackにする
        foreach(var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.command = LaneController.Command.attack;
        }
    }
    // Chargeボタンを押したときの処理
    public void OnClickCharge()
    {
        // コマンド選択状態のレーンを探し、コマンド状態をAttackにする
        foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.command = LaneController.Command.charge;
        }
    }
    // Guardボタンを押したときの処理
    public void OnClickGuard()
    {
        // コマンド選択状態のレーンを探し、コマンド状態をAttackにする
        foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.command = LaneController.Command.guard;
        }
    }

    // コマンドボタンを押したときの共通処理
    public void OnClickButton()
    {
        // コマンド選択状態のレーンを使用済みにする。
        foreach(var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.laneState = LaneController.LaneState.used;
            Debug.Log("レーンを使用済みにした");
        }
    }

    private void Update()
    {
        // コマンドセレクト状態のレーンがあればtrue
        isAnyLaneCS = scriptL.Any(LaneX => LaneX.laneState == LaneController.LaneState.commandSelect);
    }
}
