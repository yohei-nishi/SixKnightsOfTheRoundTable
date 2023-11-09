using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DamageCalculator : MonoBehaviour
{
    // 自軍のレーン
    public List<GameObject> LaneMine;
    public List<LaneController> scriptLM;

    // 敵軍のレーン
    public List<GameObject> LaneOpps;
    public List<OppLaneController> scriptLO;

    // 判定ボタンのオブジェクト
    [SerializeField] GameObject judgeButton;

    // GameController
    [SerializeField] private GameController gameController;

    // 判定ボタンを押したときの処理
    public void OnClickJudge()
    {
        // A,C,Dいずれかのコマンド状態のレーンのインデックスを取得
        int index = scriptLM.FindIndex(x => x.command == LaneController.Command.attack || x.command == LaneController.Command.charge || x.command == LaneController.Command.guard);
        // そのレーンのコマンドによって処理を変える
        switch(scriptLM[index].command)
        {
            case LaneController.Command.attack:
                Attack(index);
                break;
            case LaneController.Command.charge:
                Charge(index);
                break;
            case LaneController.Command.guard:
                Guard(index);
                break;
        }
        // 判定ボタンを非アクティブ化する
        judgeButton.SetActive(false);

        // 【後で相手側も】攻撃側のレーンのうちA,C,Dのものをfullに変える
        foreach(var state in scriptLM.Where(x => x.command == LaneController.Command.attack || x.command == LaneController.Command.charge || x.command == LaneController.Command.guard))
        { state.command = LaneController.Command.full; }
    }

    void Attack(int laneNum) 
    {
        switch(scriptLO[laneNum].command)
        { 
            case OppLaneController.Command.attack:
                Debug.Log("アタック成功");
                break;
            case OppLaneController.Command.charge:
                Debug.Log("クラッシュ成功");
                break;
            case OppLaneController.Command.guard:
                Debug.Log("カウンターされた");
                break;
            case OppLaneController.Command.empty:
                Debug.Log("ストライク成功");
                break;
            case OppLaneController.Command.full:
                Debug.Log("攻撃失敗");
                break;
        }
    }

    void Charge(int laneNum)
    {
        switch(scriptLO[laneNum].command)
        {
            case OppLaneController.Command.attack:
                Debug.Log("クラッシュされた");
                break;
            case OppLaneController.Command.charge:
                Debug.Log("お互いにチャージした");
                break;
            case OppLaneController.Command.guard:
                Debug.Log("チャージに成功した"+ " 相手はコストを支払った");
                break;
            default:
                Debug.Log("チャージに成功した");
                break;
        }
    }

    void Guard(int laneNum) 
    {
        switch (scriptLO[laneNum].command)
        {
            case OppLaneController.Command.attack:
                Debug.Log("カウンター成功");
                break;
            case OppLaneController.Command.charge:
                Debug.Log("コストを支払った" + " 相手はチャージした");
                break;
            case OppLaneController.Command.guard:
                Debug.Log("お互いにコストを支払った");
                break;
            default:
                Debug.Log("コストを支払った");
                break;
        }

    }
}
