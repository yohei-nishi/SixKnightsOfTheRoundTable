using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;
using DG.Tweening;

public class LaneController : MonoBehaviour
{
    // ���[���̏�ԁo�g�p�\�A�����A�R�}���h�I���A�g�p�ς݁p
    public enum LaneState { available, lightUp, commandSelect,used }
    public LaneState laneState = LaneState.available;

    // ���[���̃R�}���h
    public enum Command { empty, attack, charge, guard, full}
    public Command command = Command.empty;

    // Inspector�Ō�����悤��Render�̕ϐ������
    [SerializeField]
    Renderer renderComponent;

    // GameController�̃I�u�W�F�N�g
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        // GameController�̃I�u�W�F�N�g���擾
        gameController = GameObject.Find("GameController");

        // EventTrigger��ݒ�
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // �����_���̉E�Ӂo�p���Ɏ��s�������֐�������
        entry.callback.AddListener((evenData) => { OnClickThis(); }); // �N���b�N���ꂽlane������lirhtUP����commandSelect�ɂ���
        entry.callback.AddListener((evenData => { }));�@// UI�{�^�����N���b�N���ꂽ���[����ɏo��������B
        entry.callback.AddListener((evenData) => { gameController.GetComponent<GameController>().OnClickLane(); }); // �I����Ԃ̃L�������g�p�s�ɂ��āA�c��̃��[����available�ɖ߂�
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        // ��Ԃ��ƂɐF��ς���
        switch (laneState)
        { 
            case LaneState.available:
                this.renderComponent.material.DOColor(Color.blue, 0.2f);
                break;
            case LaneState.lightUp:
                this.renderComponent.material.DOColor(Color.red, 0.2f);
                break;
            case LaneState.commandSelect:
                this.renderComponent.material.DOColor(Color.yellow, 0.2f);
                break;
            case LaneState.used:
                this.renderComponent.material.DOColor(Color.green, 0.2f);
                break;
        }
    }

    // ���̃��[�����N���b�N���ꂽ�Ƃ�
    public void OnClickThis()
    {
        if(laneState == LaneState.lightUp)
        {
            // ������ԂȂ�g�p�ς݂ɂ���
            Debug.Log("�R�}���h�I����Ԃɂ���");
            laneState= LaneState.commandSelect;
        }
    }
}
