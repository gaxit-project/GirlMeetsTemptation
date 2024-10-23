using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float firstSpeed;
    public Camera playcamera;
    private int currentLane = 1; // 0: 左, 1: 中央, 2: 右 (初期位置は中央)
    private bool phoneOn = true;      
    private float elapsedTime = 0f;  // 経過時間を保持する変数
    private bool isCounting = false;  // 計測中かどうかを示すフラグ   
    private Quaternion targetRotation;// カメラのターゲットとなる回転角度を設定
    // Start is called before the first frame update
    void Start()
    {
        // 初期回転角度を設定
        targetRotation = playcamera.transform.rotation;
        firstSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Shiftキーを押している間はプレイヤーを停止させる
        if (!Input.GetKey(KeyCode.LeftShift))
        {       
            // 前進
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            //moveSpeed += Time.deltaTime * 0.01f;
        }else{
        }
        // 左への移動
        if ((Input.GetKeyDown(KeyCode.A)) && currentLane > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            currentLane--;
            MoveToLane();
        }

        // 右への移動
        if ((Input.GetKeyDown(KeyCode.D)) && currentLane < 2 && !Input.GetKey(KeyCode.LeftShift))
        {
            currentLane++;
            MoveToLane();
        }

        //カメラの向きを変える
        if (Input.GetKeyDown(KeyCode.Q))
        {
            phoneOn=!phoneOn;
            if(!phoneOn){
                elapsedTime = 0f;
                isCounting = false;
                targetRotation = Quaternion.Euler(/*32*/0, playcamera.transform.rotation.eulerAngles.y, playcamera.transform.rotation.eulerAngles.z);
            }else{
                isCounting = true;  // phoneOn が true のときは計測を停止
                targetRotation = Quaternion.Euler(55, playcamera.transform.rotation.eulerAngles.y, playcamera.transform.rotation.eulerAngles.z);
            }
        }
        // 現在の回転からターゲットの回転にゆっくりと変更する
        playcamera.transform.rotation = Quaternion.Slerp(playcamera.transform.rotation, targetRotation, Time.deltaTime * 2f);
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
