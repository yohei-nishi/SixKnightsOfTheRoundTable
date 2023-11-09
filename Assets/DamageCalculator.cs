using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DamageCalculator : MonoBehaviour
{
    // ���R�̃��[��
    public List<GameObject> LaneMine;
    public List<LaneController> scriptLM;

    // �G�R�̃��[��
    public List<GameObject> LaneOpps;
    public List<OppLaneController> scriptLO;

    // ����{�^���̃I�u�W�F�N�g
    [SerializeField] GameObject judgeButton;

    // GameController
    [SerializeField] private GameController gameController;

    // ����{�^�����������Ƃ��̏���
    public void OnClickJudge()
    {
        // A,C,D�����ꂩ�̃R�}���h��Ԃ̃��[���̃C���f�b�N�X���擾
        int index = scriptLM.FindIndex(x => x.command == LaneController.Command.attack || x.command == LaneController.Command.charge || x.command == LaneController.Command.guard);
        // ���̃��[���̃R�}���h�ɂ���ď�����ς���
        switch(scriptLM[index].command)
        {
            case LaneController.Command.attack:
                Attack(index);
                break;
            case LaneController.Command.charge:
                Charge(index);
                break;
            case LaneController.Command.guard:
                Guard(index);
                break;
        }
        // ����{�^�����A�N�e�B�u������
        judgeButton.SetActive(false);

        // �y��ő��葤���z�U�����̃��[���̂���A,C,D�̂��̂�full�ɕς���
        foreach(var state in scriptLM.Where(x => x.command == LaneController.Command.attack || x.command == LaneController.Command.charge || x.command == LaneController.Command.guard))
        { state.command = LaneController.Command.full; }
    }

    void Attack(int laneNum) 
    {
        switch(scriptLO[laneNum].command)
        { 
            case OppLaneController.Command.attack:
                Debug.Log("�A�^�b�N����");
                break;
            case OppLaneController.Command.charge:
                Debug.Log("�N���b�V������");
                break;
            case OppLaneController.Command.guard:
                Debug.Log("�J�E���^�[���ꂽ");
                break;
            case OppLaneController.Command.empty:
                Debug.Log("�X�g���C�N����");
                break;
            case OppLaneController.Command.full:
                Debug.Log("�U�����s");
                break;
        }
    }

    void Charge(int laneNum)
    {
        switch(scriptLO[laneNum].command)
        {
            case OppLaneController.Command.attack:
                Debug.Log("�N���b�V�����ꂽ");
                break;
            case OppLaneController.Command.charge:
                Debug.Log("���݂��Ƀ`���[�W����");
                break;
            case OppLaneController.Command.guard:
                Debug.Log("�`���[�W�ɐ�������"+ " ����̓R�X�g���x������");
                break;
            default:
                Debug.Log("�`���[�W�ɐ�������");
                break;
        }
    }

    void Guard(int laneNum) 
    {
        switch (scriptLO[laneNum].command)
        {
            case OppLaneController.Command.attack:
                Debug.Log("�J�E���^�[����");
                break;
            case OppLaneController.Command.charge:
                Debug.Log("�R�X�g���x������" + " ����̓`���[�W����");
                break;
            case OppLaneController.Command.guard:
                Debug.Log("���݂��ɃR�X�g���x������");
                break;
            default:
                Debug.Log("�R�X�g���x������");
                break;
        }

    }
}
