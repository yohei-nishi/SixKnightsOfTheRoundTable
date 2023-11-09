using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;
using DG.Tweening;

public class CharactorController : MonoBehaviour
{
    // キャラの状態
    public enum CharactorState { idle, selected, disable }
    public CharactorState charactorState = CharactorState.idle;

    // [未完]　Inspectorで見えるようにRenderの変数を作る
    [SerializeField]
    SpriteRenderer sprite;

    // GameControllerのオブジェクト
    public GameObject gameController;
    [SerializeField] GameController scriptGC;

    // Start is called before the first frame update
    void Start()
    {
        // 【未完】キャラの画像を取得
        this.sprite = GetComponent<SpriteRenderer>();

        // EventTriggerを設定
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // ラムダ式の右辺｛｝内に実行したい関数を入れる
        entry.callback.AddListener((evenData) => { scriptGC.OnClickChara(); });
        entry.callback.AddListener((evenData) => { OnClickThis(); });
        entry.callback.AddListener((evenData) => { scriptGC.OnClickChara2(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {

    }
       

    // キャラがクリックされたときに実行される処理
    public void OnClickThis()
    {
        // キャラが待機状態かつ全てのレーンがコマンド選択状態ではなく、ダメージ演出中では無いのなら
        if (charactorState == CharactorState.idle && !scriptGC.isAnyLaneCS && !scriptGC.isInJudge) 
        {
            Debug.Log("選択状態にした");
            charactorState = CharactorState.selected;
            sprite.DOFade(0.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("Fade");
        }
    }

    // レーンがクリックされたときに実行される処理
    public void OnClickLane()
    {
        // キャラが選択状態なら
        if (charactorState == CharactorState.selected)
        {
            Debug.Log("選択不可にした");
            charactorState = CharactorState.disable;
            

            // 【予定】発光を元に戻し、カードを移動する
        }
    }

   
}
