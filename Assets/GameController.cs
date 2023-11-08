using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static CharactorController;

public class GameController : MonoBehaviour
{
    // �L�����ƃ��[���̃I�u�W�F�N�g�ƃX�N���v�g�����郊�X�g
    public List<GameObject> charactor;
    public List<GameObject> Lane;
    public List<CharactorController> scriptC;
    public List<LaneController> scriptL;
    public List<Transform> laneTransform;

    // �R�}���h�I����Ԃ̃��[�������邩�ۂ��i�L�������I����ԂɂȂ�邩�̏����Ɏg�p�j
    public bool isAnyLaneCS;

    // �R�}���h�I����Ԃ̃��[��
    public GameObject laneCS;

    // �R�}���h�I����Ԃ̃��[���̍��W
    public Transform laneCsTransfom;

    // canvas�Ɛ����������{�^����
    [SerializeField] List<GameObject> commadButton;

    // Canvas�̍��W
    [SerializeField] RectTransform canvasRect;
    
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
        // �I����Ԃ̃L������I��s�ɂ���
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
        // �R�}���h�I����Ԃ̃��[���������
        if (scriptL.Any(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            // FindIndex�ŃR�}���h�I����Ԃ̃X�N���v�g�̃C���f�b�N�X���擾���A�Ή�����g�����X�t�H�[�����C���f�b�N�X�Ŏw�肵�擾�B
            var index = scriptL.FindIndex(x => x.laneState == LaneController.LaneState.commandSelect);
            laneCsTransfom = laneTransform[index];

            // UI�{�^�����A�N�e�B�u�ɂ���
            foreach(var active in commadButton)
            { active.SetActive(true); }
        }
    }

    // Attack�{�^�����������Ƃ��̏���
    public void OnClickAttack()
    {
        // �R�}���h�I����Ԃ̃��[����T���A�R�}���h��Ԃ�Attack�ɂ���
        foreach(var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.command = LaneController.Command.attack;
        }
    }
    // Charge�{�^�����������Ƃ��̏���
    public void OnClickCharge()
    {
        // �R�}���h�I����Ԃ̃��[����T���A�R�}���h��Ԃ�Attack�ɂ���
        foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.command = LaneController.Command.charge;
        }
    }
    // Guard�{�^�����������Ƃ��̏���
    public void OnClickGuard()
    {
        // �R�}���h�I����Ԃ̃��[����T���A�R�}���h��Ԃ�Attack�ɂ���
        foreach (var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.command = LaneController.Command.guard;
        }
    }

    // �R�}���h�{�^�����������Ƃ��̋��ʏ���
    public void OnClickButton()
    {
        // �R�}���h�I����Ԃ̃��[�����g�p�ς݂ɂ���B
        foreach(var state in scriptL.Where(x => x.laneState == LaneController.LaneState.commandSelect))
        {
            state.laneState = LaneController.LaneState.used;
            Debug.Log("���[�����g�p�ς݂ɂ���");
        }
    }

    private void Update()
    {
        // �R�}���h�Z���N�g��Ԃ̃��[���������true
        isAnyLaneCS = scriptL.Any(LaneX => LaneX.laneState == LaneController.LaneState.commandSelect);
    }
}
