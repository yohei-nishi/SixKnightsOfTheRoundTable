using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharactorController : MonoBehaviour
{
    // カードの選択状態｛待機、選択、選択不可｝
    public enum State { idle, selected, disable }
    public State state = State.idle;

    // Start is called before the first frame update
    void Start()
    {
        // EventTriggerを設定
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // ラムダ式の右辺｛｝内に実行したいクラスを入れる
        entry.callback.AddListener((evenData) => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
