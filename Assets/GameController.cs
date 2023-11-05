using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static CharactorController;

public class GameController : MonoBehaviour
{
    // �L�����ƃ��[���̃I�u�W�F�N�g�����郊�X�g
    public GameObject[] charactor;
    public GameObject[] Lane;
    public CharactorController[] scriptC;
    public LaneController[] scriptL;
    
    // �L�������N���b�N�����Ƃ��A���ɑI����Ԃ̃L������ҋ@��Ԃɖ߂�����
    public void OnClickChara()
    {
        foreach (var state in scriptC.Where(x => x.charactorState == CharactorState.selected))
        { 
            state.charactorState = CharactorController.CharactorState.idle;
            DOTween.Kill("Fade");
        }
    }

    // �L�������N���b�N�����Ƃ��A�L�����̑I����Ԃɉ����ă��[���̏�Ԃ�ς��鏈��
    public void OnClickChara2()
    {
        // �I����Ԃ̃L�����N�^�[������΃��[���𔭌���ԂɁA
        if (scriptC.Any(state => state.charactorState == CharactorState.selected))
        {
            foreach(var state in scriptL.Where(x => x.laneState == LaneController.LaneState.available))
            {
                state.laneState = LaneController.LaneState.lightUp;
                Debug.Log("���[���𔭌�������");

            }
        } 
        // ���Ȃ���΃��[�����g�p�\��Ԃ�
        else
        {
            foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.lightUp))
            {
                state.laneState = LaneController.LaneState.available;
                Debug.Log("���[�����g�p�\�ɖ߂���");
            }
        }
    }

    // ���[�����N���b�N�����Ƃ��̏���
    public void OnClickLane()
    {
        foreach (var state in scriptC.Where(x => x.charactorState == CharactorState.selected))
        {
            state.charactorState = CharactorController.CharactorState.disable;
            DOTween.Kill("Fade");
            Debug.Log("�L������I��s�ɂ���");
        }
        // �g��Ȃ��������[����avalable�ɖ߂�
        foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.lightUp))
        {
            state.laneState = LaneController.LaneState.available;
            Debug.Log("���[�����g�p�\�ɖ߂���");
        }
    }
}
