using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharactorController : MonoBehaviour
{
    // �J�[�h�̑I����ԁo�ҋ@�A�I���A�I��s�p
    public enum State { idle, selected, disable }
    public State state = State.idle;

    // Start is called before the first frame update
    void Start()
    {
        // EventTrigger��ݒ�
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // �����_���̉E�Ӂo�p���Ɏ��s�������N���X������
        entry.callback.AddListener((evenData) => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
