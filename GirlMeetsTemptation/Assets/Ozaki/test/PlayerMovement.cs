using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float firstSpeed;
    public Camera playcamera;
    private int currentLane = 1; // 0: 左, 1: 中央, 2: 右 (初期位置は中央)
    private bool phoneOn = true;      
    private float elapsedTime = 0f;  // 経過時間を保持する変数
    private bool isCounting = false;  // 計測中かどうかを示すフラグ
    private bool walk = true;//歩いているかフラグ
    private bool hasFallen = false;  // 落ちたかどうかを管理するフラグ
    private Quaternion targetRotation;// カメラのターゲットとなる回転角度を設定
    private Holedead holedead;

    private InputAction MoveRAction;//右移動ボタンの押下状態
    private InputAction MoveLAction;//左移動ボタンの押下状態
    private InputAction ButtonBAction;//Bボタンの押下状態
    public GameObject phoneUI;

    // Start is called before the first frame update
    void Start()
    {
        // 初期回転角度を設定
        targetRotation = playcamera.transform.rotation;
        firstSpeed = moveSpeed;
        holedead = FindObjectOfType<Holedead>();
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
        if(holedead == null){
            holedead = FindObjectOfType<Holedead>();
        }
        //InputSystem用
        bool MoveR = MoveRAction.triggered;
        bool MoveL = MoveLAction.triggered;
        bool ButtonB = ButtonBAction.triggered;
        
        // Shiftキーを押している間はプレイヤーを停止させる
        if (!Input.GetKey(KeyCode.LeftShift))
        {       
            // 前進
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            if(walk){
                Audio.GetInstance().PlaySound(0);
                walk = false;
            }
        }else{
            Audio.GetInstance().StopLoopSound(); 
            walk = true;
        }
        // 左への移動
        if (MoveL && currentLane > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            currentLane--;
            MoveToLane();
        }

        // 右への移動
        if (MoveR && currentLane < 2 && !Input.GetKey(KeyCode.LeftShift))
        {
            currentLane++;
            MoveToLane();
        }

        //カメラの向きを変える
        if (ButtonB)
        {
            phoneOn=!phoneOn;
            if(!phoneOn){
                elapsedTime = 0f;
                isCounting = false;
                targetRotation = Quaternion.Euler(/*32*/0, playcamera.transform.rotation.eulerAngles.y, playcamera.transform.rotation.eulerAngles.z);
            }else{
                isCounting = true;  // phoneOn が true のときは計測を停止
                Audio.GetInstance().PlaySound(1);
                targetRotation = Quaternion.Euler(55, playcamera.transform.rotation.eulerAngles.y, playcamera.transform.rotation.eulerAngles.z);
            }
        }
        
        // 現在の回転からターゲットの回転にゆっくりと変更する
        playcamera.transform.rotation = Quaternion.Slerp(playcamera.transform.rotation, targetRotation, Time.deltaTime * 2f);

        if (phoneOn)
        {
            phoneUI.SetActive(true);
        }
        else
        {
            phoneUI.SetActive(false);
        }
    }

    public bool CheckTime(){// スマホ経過時間を加算
        if(isCounting){
            elapsedTime += Time.deltaTime;  
        }else{
            elapsedTime = 0f;
        }
        // 10秒が経過したかを判
        if (elapsedTime >= 10f && isCounting)
        {
            return true;
        }
        return false;
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
    void OnTriggerEnter(Collider other)
    {
        // タグが "player" のオブジェクトに当たった場合
        if (other.CompareTag("Passenger"))
        {
        // 後ろに少し下がるための力を加える
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 knockback = -transform.forward * 5f; // 後ろに2の力を加える
            rb.AddForce(knockback, ForceMode.VelocityChange);
        }

        // 一定時間、動きが遅くなる
        StartCoroutine(SlowDownTemporarily());
        }
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

    IEnumerator SlowDownTemporarily()
    {
        moveSpeed = moveSpeed / 3;       // 速度を半分にする
        yield return new WaitForSeconds(5f); // 5秒間動きを遅くする
        moveSpeed = firstSpeed;        // 元の速度に戻す
    }

}
