using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{
    // カード選択状態。
    public enum State { idle, selected, disable}
    public State state = State.idle;

    public void Start()
    {
        // 【あとで消す】if else の代わりに使えるやーつ
        switch (state)
        {
            case State.idle:
                // アイドル状態の処理
                break;
            case State.selected:
                break;
            case State.disable:
                break;
        }
    }

    // キャラがクリックされたときに実行されるクラス
    public void OnClickCharactor()
    {
        // キャラが待機状態なら
        if(state == State.idle)
        {
            Debug.Log("選択状態にした");
            state = State.selected;

            // 【予定】キャラと選択可能なレーンを光らせる
        }
    }

    // レーンがクリックされたときに実行されるクラス
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

    // 【予定】ターン終了時、Statusを０にしてカードの位置を戻す。
}
