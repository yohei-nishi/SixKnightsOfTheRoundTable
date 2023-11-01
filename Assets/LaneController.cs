using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaneController : MonoBehaviour
{
    // ���[���̏��
    public enum State { available, lightUp, used }
    public State state = State.available;

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
