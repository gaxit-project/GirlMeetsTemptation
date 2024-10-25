using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PMoveCopy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Camera playcamera;
    private int currentLane = 1; // 0: 左, 1: 中央, 2: 右 (初期位置は中央)
    private bool phoneOn = true;          
    private Quaternion targetRotation;// カメラのターゲットとなる回転角度を設定

    private InputAction MoveRAction;//右移動ボタンの押下状態
    private InputAction MoveLAction;//左移動ボタンの押下状態
    private InputAction ButtonBAction;//Bボタンの押下状態

    public GameObject phoneUI;

    // Start is called before the first frame update
    void Start()
    {
        // 初期回転角度を設定
        targetRotation = playcamera.transform.rotation;

        //InputSystem用
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        MoveRAction = actionMap["MoveR"];
        MoveLAction = actionMap["MoveL"];
        ButtonBAction = actionMap["ButtonB"];
    }

    // Update is called once per frame
    void Update()
    {
        //InputSystem用
        bool MoveR = MoveRAction.triggered;
        bool MoveL = MoveLAction.triggered;
        bool ButtonB = ButtonBAction.triggered;

        Debug.Log("MR=" + MoveR + " ML=" + MoveL + " B=" + ButtonB);

        // Shiftキーを押している間はプレイヤーを停止させる
        if (/*!Input.GetKey(KeyCode.LeftShift) || */!MoveR && !MoveL)
        {
            // 前進
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            moveSpeed += Time.deltaTime * 0.01f;
        }
        // 左への移動
        if ((/*Input.GetKeyDown(KeyCode.A) ||*/ MoveL) && currentLane > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            currentLane--;
            MoveToLane();
        }

        // 右への移動
        if ((/*Input.GetKeyDown(KeyCode.D) ||*/ MoveR) && currentLane < 2 && !Input.GetKey(KeyCode.LeftShift))
        {
            currentLane++;
            MoveToLane();
        }

        //カメラの向きを変える
        if (/*Input.GetKeyDown(KeyCode.Q) ||*/ ButtonB)
        {
            phoneOn=!phoneOn;
            if(!phoneOn){
            targetRotation = Quaternion.Euler(/*32*/0, playcamera.transform.rotation.eulerAngles.y, playcamera.transform.rotation.eulerAngles.z);
            }else{
            targetRotation = Quaternion.Euler(55, playcamera.transform.rotation.eulerAngles.y, playcamera.transform.rotation.eulerAngles.z);
            }
        }
        // 現在の回転からターゲットの回転にゆっくりと変更する
        playcamera.transform.rotation = Quaternion.Slerp(playcamera.transform.rotation, targetRotation, Time.deltaTime * 2f);

        if (phoneOn && !ButtonManager.TwiXFlag)
        {
            phoneUI.SetActive(true);
        }
        else
        {
            phoneUI.SetActive(false);
        }
    }

    // レーン間の移動を行う関数
    void MoveToLane()
    {
        Vector3 targetPosition = transform.position;

        // レーンごとのX座標を設定 (中央レーンを基準にして左右に移動)
        targetPosition.x = currentLane * 1f; 
        
        // スムーズにレーン移動するためのコルーチンを開始
        StartCoroutine(LerpPosition(targetPosition));
    }
    public bool getphoneOn(){
        return phoneOn;
    }

    public void setphoneOn(bool phone){
        phoneOn = phone;
    }

    // スムーズなレーン移動
    IEnumerator LerpPosition(Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < 1f)
        {
            time += Time.deltaTime * 4f;
            transform.position = Vector3.Lerp(startPosition, targetPosition, time);
            yield return null;
        }
    }
}
