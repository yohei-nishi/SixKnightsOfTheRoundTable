using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // カメラ

    // ボタンを表示させる対象：レーン
    [SerializeField] public Transform targetTransform;

    // 表示するUIボタンの位置
    [SerializeField] public Transform myRectTransform;

    // ボタンを表示させるときのオフセット（オブジェクトの相対座標）
    [SerializeField] public Vector3 offset;

    // Canvasの位置
    [SerializeField] public RectTransform canvas;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameControllerから対象となるオブジェクトの座標を取得
        targetTransform = gameController.laneCsTransfom;
        // オフセットを加え、スクリーン座標に変換
        transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTransform.position + offset);
    }

    public void OnClickButton()
    {
        gameObject.SetActive(false);
    }
}
