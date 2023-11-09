using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameController;
using DG.Tweening;

public class CharactorController : MonoBehaviour
{
    // �L�����̏��
    public enum CharactorState { idle, selected, disable }
    public CharactorState charactorState = CharactorState.idle;

    // [����]�@Inspector�Ō�����悤��Render�̕ϐ������
    [SerializeField]
    SpriteRenderer sprite;

    // GameController�̃I�u�W�F�N�g
    public GameObject gameController;
    [SerializeField] GameController scriptGC;

    // Start is called before the first frame update
    void Start()
    {
        // �y�����z�L�����̉摜���擾
        this.sprite = GetComponent<SpriteRenderer>();

        // EventTrigger��ݒ�
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // �����_���̉E�Ӂo�p���Ɏ��s�������֐�������
        entry.callback.AddListener((evenData) => { scriptGC.OnClickChara(); });
        entry.callback.AddListener((evenData) => { OnClickThis(); });
        entry.callback.AddListener((evenData) => { scriptGC.OnClickChara2(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {

    }
       

    // �L�������N���b�N���ꂽ�Ƃ��Ɏ��s����鏈��
    public void OnClickThis()
    {
        // �L�������ҋ@��Ԃ��S�Ẵ��[�����R�}���h�I����Ԃł͂Ȃ��A�_���[�W���o���ł͖����̂Ȃ�
        if (charactorState == CharactorState.idle && !scriptGC.isAnyLaneCS && !scriptGC.isInJudge) 
        {
            Debug.Log("�I����Ԃɂ���");
            charactorState = CharactorState.selected;
            sprite.DOFade(0.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("Fade");
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
