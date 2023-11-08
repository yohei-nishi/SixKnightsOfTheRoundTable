using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // �J����

    // �{�^����\��������ΏہF���[��
    [SerializeField] public Transform targetTransform;

    // �\������UI�{�^���̈ʒu
    [SerializeField] public Transform myRectTransform;

    // �{�^����\��������Ƃ��̃I�t�Z�b�g�i�I�u�W�F�N�g�̑��΍��W�j
    [SerializeField] public Vector3 offset;

    // Canvas�̈ʒu
    [SerializeField] public RectTransform canvas;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameController����ΏۂƂȂ�I�u�W�F�N�g�̍��W���擾
        targetTransform = gameController.laneCsTransfom;
        // �I�t�Z�b�g�������A�X�N���[�����W�ɕϊ�
        transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTransform.position + offset);
    }

    public void OnClickButton()
    {
        gameObject.SetActive(false);
    }
}
