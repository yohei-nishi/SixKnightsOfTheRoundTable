using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharactorController;

public class GameController : MonoBehaviour
{

    // �L�����ƃ��[���̃I�u�W�F�N�g
    public GameObject charactor1;
    public GameObject charactor2;
    public GameObject charactor3;
    public GameObject charactor4;
    public GameObject charactor5;
    public GameObject charactor6;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    public GameObject lane5;
    public GameObject lane6;
    public GameObject lane7;
    public GameObject lane8;
    public GameObject lane9;
    public GameObject lane10;

    // �L�����ƃ��[���̃X�N���v�g
    public CharactorController scriptCC1;
    public CharactorController scriptCC2;
    public CharactorController scriptCC3;
    public CharactorController scriptCC4;
    public CharactorController scriptCC5;
    public CharactorController scriptCC6;
    public LaneController      scriptLC1;
    public LaneController      scriptLC2;
    public LaneController      scriptLC3;
    public LaneController      scriptLC4;
    public LaneController      scriptLC5;

    // �L�����ƃ��[���̑I���̌^

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
        this.lane1      = GameObject.Find("BattleLane1");
        this.lane2      = GameObject.Find("BattleLane2");
        this.lane3      = GameObject.Find("BattleLane3");
        this.lane4      = GameObject.Find("BattleLane4");
        this.lane5      = GameObject.Find("BattleLane5");
        this.lane6      = GameObject.Find("BattleLane6");
        this.lane7      = GameObject.Find("BattleLane7");
        this.lane8      = GameObject.Find("BattleLane8");
        this.lane9      = GameObject.Find("BattleLane9");
        this.lane10     = GameObject.Find("BattleLane10");

        // �X�N���v�g���擾
        scriptCC1 = charactor1.GetComponent<CharactorController>();
        scriptCC2 = charactor2.GetComponent<CharactorController>();
        scriptCC3 = charactor3.GetComponent<CharactorController>();
        scriptCC4 = charactor4.GetComponent<CharactorController>();
        scriptCC5 = charactor5.GetComponent<CharactorController>();
        scriptCC6 = charactor6.GetComponent<CharactorController>();
        scriptLC1 = lane1.GetComponent<LaneController>();
        scriptLC2 = lane2.GetComponent<LaneController>();
        scriptLC3 = lane3.GetComponent<LaneController>();
        scriptLC4 = lane4.GetComponent<LaneController>();
        scriptLC5 = lane5.GetComponent<LaneController>();

        // �e�L�����ƃ��[����State��������

    }

    // Update is called once per frame
    void Update()
    {
        // �e�L�����ƃ��[����State���Ď�
        
    }

    // �J�[�h���N���b�N�����Ƃ��̏���
    public void OnClickChara()
    {
        // �I����Ԃ̃L������ҋ@�ɖ߂�
        if (scriptCC1.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����1��ҋ@��Ԃɖ߂���");
            scriptCC1.charactorState = CharactorState.idle;
        }
        if (scriptCC2.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����2��ҋ@��Ԃɖ߂���");
            scriptCC2.charactorState = CharactorState.idle;
        }
        if (scriptCC3.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����3��ҋ@��Ԃɖ߂���");
            scriptCC3.charactorState = CharactorState.idle;
        }
        if (scriptCC4.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����4��ҋ@��Ԃɖ߂���");
            scriptCC4.charactorState = CharactorState.idle;
        }
        if (scriptCC5.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����5��ҋ@��Ԃɖ߂���");
            scriptCC5.charactorState = CharactorState.idle;
        }
        if (scriptCC6.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����6��ҋ@��Ԃɖ߂���");
            scriptCC6.charactorState = CharactorState.idle;
        }
    }

    // 
    public void OnClickChara2()
    {
        // �ҋ@��Ԃ̃L�����N�^�[������΃��[���𔭌���ԂɁA
        if (scriptCC1.charactorState == CharactorState.selected || 
            scriptCC2.charactorState == CharactorState.selected ||
            scriptCC3.charactorState == CharactorState.selected ||
            scriptCC4.charactorState == CharactorState.selected ||
            scriptCC5.charactorState == CharactorState.selected ||
            scriptCC6.charactorState == CharactorState.selected   )
        {
            if (scriptLC1.laneState == LaneController.LaneState.available)
            {
                Debug.Log("���[��1�𔭌���Ԃɂ���");
                scriptLC1.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC2.laneState == LaneController.LaneState.available)
            {
                Debug.Log("���[��2�𔭌���Ԃɂ���");
                scriptLC2.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC3.laneState == LaneController.LaneState.available)
            {
                Debug.Log("���[��3�𔭌���Ԃɂ���");
                scriptLC3.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC4.laneState == LaneController.LaneState.available)
            {
                Debug.Log("���[��4�𔭌���Ԃɂ���");
                scriptLC4.laneState = LaneController.LaneState.lightUp;
            }
            if (scriptLC5.laneState == LaneController.LaneState.available)
            {
                Debug.Log("���[��5�𔭌���Ԃɂ���");
                scriptLC5.laneState = LaneController.LaneState.lightUp;
            }
        }
        // ���Ȃ���΃��[�����g�p�\��Ԃ�
        else
        {
            if (scriptLC1.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("���[��1���g�p�\�ɂ���");
                scriptLC1.laneState = LaneController.LaneState.available;
            }
            if (scriptLC2.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("���[��2���g�p�\�ɂ���");
                scriptLC2.laneState = LaneController.LaneState.available;
            }
            if (scriptLC3.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("���[��3�g�p�\�ɂ���");
                scriptLC3.laneState = LaneController.LaneState.available;
            }
            if (scriptLC4.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("���[��4���g�p�\�ɂ���");
                scriptLC4.laneState = LaneController.LaneState.available;
            }
            if (scriptLC5.laneState == LaneController.LaneState.lightUp)
            {
                Debug.Log("���[��5���g�p�\�ɂ���");
                scriptLC5.laneState = LaneController.LaneState.available;
            }
        }
    }

    // ���[�����N���b�N�����Ƃ��̏���
    public void OnClickLane()
    {
        if (scriptCC1.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����1��I��s�ɂ���");
            scriptCC1.charactorState = CharactorState.disable;
        }
        if (scriptCC2.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����2��I��s�ɂ���");
            scriptCC2.charactorState = CharactorState.disable;
        }
        if (scriptCC3.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����3��I��s�ɂ���");
            scriptCC3.charactorState = CharactorState.disable;
        }
        if (scriptCC4.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����4��I��s�ɂ���");
            scriptCC4.charactorState = CharactorState.disable;
        }
        if (scriptCC5.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����5��I��s�ɂ���");
            scriptCC5.charactorState = CharactorState.disable;
        }
        if (scriptCC6.charactorState == CharactorState.selected)
        {
            Debug.Log("�L����6��I��s�ɂ���");
            scriptCC6.charactorState = CharactorState.disable;
        }
        if (scriptLC1.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("���[��1���g�p�\�ɖ߂���");
            scriptLC1.laneState = LaneController.LaneState.available;
        }
        if (scriptLC2.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("���[��2���g�p�\�ɖ߂���");
            scriptLC2.laneState = LaneController.LaneState.available;
        }
        if (scriptLC3.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("���[��3���g�p�\�ɖ߂���");
            scriptLC3.laneState = LaneController.LaneState.available;
        }
        if (scriptLC4.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("���[��4���g�p�\�ɖ߂���");
            scriptLC4.laneState = LaneController.LaneState.available;
        }
        if (scriptLC5.laneState == LaneController.LaneState.lightUp)
        {
            Debug.Log("���[��5���g�p�\�ɖ߂���");
            scriptLC5.laneState = LaneController.LaneState.available;
        }
    }
}
