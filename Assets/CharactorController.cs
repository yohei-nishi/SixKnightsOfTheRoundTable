using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;

public class CharactorController : MonoBehaviour
{
    // �L�����̏��
    public enum CharactorState { idle, selected, disable }
    public CharactorState charactorState = CharactorState.idle;

    // GameController�̃I�u�W�F�N�g
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");

        // EventTrigger��ݒ�
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // �����_���̉E�Ӂo�p���Ɏ��s�������֐�������
        entry.callback.AddListener((evenData) => { gameController.GetComponent<GameController>().OnClickChara(); });
        entry.callback.AddListener((evenData) => { OnClickThis(); });
        entry.callback.AddListener((evenData) => { gameController.GetComponent<GameController>().OnClickChara2(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �L�������N���b�N���ꂽ�Ƃ��Ɏ��s����鏈��
    public void OnClickThis()
    {
        // �L�������ҋ@��ԂȂ�
        if (charactorState == CharactorState.idle)
        {
            Debug.Log("�I����Ԃɂ���");
            charactorState = CharactorState.selected;

            // ���̃L���������点��
            // ���̃L�������I����ԂȂ�ҋ@�ɖ߂�
        }
    }

    // ���[�����N���b�N���ꂽ�Ƃ��Ɏ��s����鏈��
    public void OnClickLane()
    {
        // �L�������I����ԂȂ�
        if (charactorState == CharactorState.selected)
        {
            Debug.Log("�I��s�ɂ���");
            charactorState = CharactorState.disable;

            // �y�\��z���������ɖ߂��A�J�[�h���ړ�����
        }
    }

   
}
