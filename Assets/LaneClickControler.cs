using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaneClickControler : MonoBehaviour
{

    // ���[���̏��
    public enum State { available, lightUp, used }
    public State state = State.available;

    // �I�u�W�F�N�g�̊�
    public GameObject charactor1;
    public GameObject charactor2;
    public GameObject charactor3;
    public GameObject charactor4;
    public GameObject charactor5;
    public GameObject charactor6;

    // �X�N���v�g�̊�
    public TouchSensor script1;
    public TouchSensor script2;
    public TouchSensor script3;
    public TouchSensor script4;
    public TouchSensor script5;
    public TouchSensor script6;

    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g���擾
        this.charactor1 = GameObject.Find("�p�t�@����");
        this.charactor2 = GameObject.Find("��m�@����");
        this.charactor3 = GameObject.Find("�R�m�@����");
        this.charactor4 = GameObject.Find("��l�@����");
        this.charactor5 = GameObject.Find("��ԁ@����");
        this.charactor6 = GameObject.Find("�B�ҁ@����");

        // �X�N���v�g���擾
        script1 = charactor1.GetComponent<TouchSensor>();
        script2 = charactor2.GetComponent<TouchSensor>();
        script3 = charactor3.GetComponent<TouchSensor>();
        script4 = charactor4.GetComponent<TouchSensor>();
        script5 = charactor5.GetComponent<TouchSensor>();
        script6 = charactor6.GetComponent<TouchSensor>();


        // EventTrigger��ݒ肷��
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        // ���X�g�ɉ��������֐��������_���̉E�ӂɓ����
        entry.callback.AddListener((evenData) => { OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script1.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script2.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script3.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script4.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script5.OnClickLane(); });
        entry.callback.AddListener((evenDate) => { script6.OnClickLane(); });
        trigger.triggers.Add(entry);
    }

    // ���[�����N���b�N���ꂽ�Ƃ��̏���
    public void OnClickLane()
    {
        // ���[����������ԂȂ�
        if (state == State.lightUp)
        {
            Debug.Log("���[�����I�����ꂽ");
            state = State.used;
        }
    }

    // �J�[�h���N���b�N���ꂽ�Ƃ�
    public void OnClickCharactorCard()
    {
        // �g�p�\��ԂȂ�
        if (state == State.available)
        {
            Debug.Log("���[���͔�����ԂɂȂ�");
            state = State.lightUp;
        }
    }
}
