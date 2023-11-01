using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSensor : MonoBehaviour
{
    // �J�[�h�I����ԁB
    public enum State { idle, selected, disable}
    public State state = State.idle;

    // ���[���̃I�u�W�F�N�g
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    public GameObject lane5;

    // LaneClickController�̊�
    public LaneClickControler script1;
    public LaneClickControler script2;
    public LaneClickControler script3;
    public LaneClickControler script4;
    public LaneClickControler script5;

    private void Start()
    {
        this.lane1 = GameObject.Find("BattleLane1");
        this.lane2 = GameObject.Find("BattleLane2");
        this.lane3 = GameObject.Find("BattleLane3");
        this.lane4 = GameObject.Find("BattleLane4");
        this.lane5 = GameObject.Find("BattleLane5");

        this.script1 = lane1.GetComponent<LaneClickControler>();
        this.script2 = lane2.GetComponent<LaneClickControler>();
        this.script3 = lane3.GetComponent<LaneClickControler>();
        this.script4 = lane4.GetComponent<LaneClickControler>();
        this.script5 = lane5.GetComponent<LaneClickControler>();

        // EventTrigger��ݒ肷��
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        // ���s������������List�ɒǉ�
        entry.callback.AddListener((evenDate) => { OnClickCharactor(); });
        entry.callback.AddListener((evenDate) => { script1.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script2.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script3.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script4.OnClickCharactorCard(); });
        entry.callback.AddListener((evenDate) => { script5.OnClickCharactorCard(); });
        trigger.triggers.Add(entry);
    }

    // �L�������N���b�N���ꂽ�Ƃ��Ɏ��s����鏈��
    public void OnClickCharactor()
    {
        // �L�������ҋ@��ԂȂ�
        if(state == State.idle)
        {
            Debug.Log("�I����Ԃɂ���");
            state = State.selected;

            // ���̃L���������点��
            // ���̃L�������I����ԂȂ�ҋ@�ɖ߂�
        }
    }

    // ���[�����N���b�N���ꂽ�Ƃ��Ɏ��s����鏈��
    public void OnClickLane()
    {
        // �L�������I����ԂȂ�
        if (state == State.selected)
        {
            Debug.Log("�I��s�ɂ���");
            state = State.disable;

            // �y�\��z���������ɖ߂��A�J�[�h���ړ�����
        }
    }

    // �y�\��z���g���I����Ԃ̂Ƃ��A���̃J�[�h���I����ԂɂȂ����炱�̃J�[�h��ҋ@��Ԃɖ߂��B

    // �y�\��z�^�[���I�����AStatus��idle�ɂ��ăJ�[�h�̈ʒu��߂��B
}
