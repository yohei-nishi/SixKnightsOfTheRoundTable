using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;

public class LaneController : MonoBehaviour
{
    // ���[���̏�ԁo�g�p�\�A�����A�g�p�ς݁p
    public enum LaneState { available, lightUp, used }
    public LaneState laneState = LaneState.available;

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
        entry.callback.AddListener((evenData) => { OnClickThis(); });
        entry.callback.AddListener((evenData) => { gameController.GetComponent<GameController>().OnClickLane(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���̃��[�����N���b�N���ꂽ�Ƃ�
    public void OnClickThis()
    {
        if(laneState == LaneState.lightUp)
        {
            // ������ԂȂ�g�p�ς݂ɂ���
            Debug.Log("�g�p�ς݂ɂ���");
            laneState= LaneState.used;
        }

    }
}
