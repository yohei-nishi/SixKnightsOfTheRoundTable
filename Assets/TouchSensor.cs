using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{
    // �J�[�h�I����ԁB
    public enum State { idle, selected, disable}
    public State state = State.idle;

    public void Start()
    {
        // �y���Ƃŏ����zif else �̑���Ɏg�����[��
        switch (state)
        {
            case State.idle:
                // �A�C�h����Ԃ̏���
                break;
            case State.selected:
                break;
            case State.disable:
                break;
        }
    }

    // �L�������N���b�N���ꂽ�Ƃ��Ɏ��s�����N���X
    public void OnClickCharactor()
    {
        // �L�������ҋ@��ԂȂ�
        if(state == State.idle)
        {
            Debug.Log("�I����Ԃɂ���");
            state = State.selected;

            // �y�\��z�L�����ƑI���\�ȃ��[�������点��
        }
    }

    // ���[�����N���b�N���ꂽ�Ƃ��Ɏ��s�����N���X
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

    // �y�\��z�^�[���I�����AStatus���O�ɂ��ăJ�[�h�̈ʒu��߂��B
}
