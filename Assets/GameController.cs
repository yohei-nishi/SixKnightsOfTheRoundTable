using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public CharacterController scriptCC1;
    public CharacterController scriptCC2;
    public CharacterController scriptCC3;
    public CharacterController scriptCC4;
    public CharacterController scriptCC5;
    public CharacterController scriptCC6;
    public LaneController      scriptLC1;
    public LaneController      scriptLC2;
    public LaneController      scriptLC3;
    public LaneController      scriptLC4;
    public LaneController      scriptLC5;

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
        scriptCC1 = charactor1.GetComponent<CharacterController>();
        scriptCC2 = charactor2.GetComponent<CharacterController>();
        scriptCC3 = charactor3.GetComponent<CharacterController>();
        scriptCC4 = charactor4.GetComponent<CharacterController>();
        scriptCC5 = charactor5.GetComponent<CharacterController>();
        scriptCC6 = charactor6.GetComponent<CharacterController>();
        scriptLC1 = lane1.GetComponent<LaneController>();
        scriptLC2 = lane2.GetComponent<LaneController>();
        scriptLC3 = lane3.GetComponent<LaneController>();
        scriptLC4 = lane4.GetComponent<LaneController>();
        scriptLC5 = lane5.GetComponent<LaneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
