using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    /*
    [Header("プレイヤー")]
    public Transform Player;

    private Vector3 offset; // 初期位置との差を保持

    public Collider playerCol;
    public Collider floorCol;

    bool isFall = false;

    float time = 0f;

    void Start()
    {
        // カメラとプレイヤーの初期位置の差を計算
        offset = transform.position - Player.position;
    }


    private void Update()
    {
        // プレイヤーのx座標に追従し、yとzはそのまま維持
        transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);

        if (isFall)
        {
            time += Time.deltaTime;
            if(time > 0.3f)
            {
                playerCol.enabled = true;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = false;
                time = 0f;
            }
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            Debug.Log("↓");
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown("D"))
            {
                Debug.Log("すり抜け");
                // 衝突を一時的に無効にする
                playerCol.enabled = false; ;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                //isFall = true;
            }
        }
    }
    private void OnTriggerStay(Collider col)
    {
        // 地面に接触した場合、isGroundedをtrueにする
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            Debug.Log("↓");
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown("d"))
            {
                Debug.Log("すり抜け");
                // 衝突を一時的に無効にする
                playerCol.enabled = false;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                //isFall = true;
            }
        }
    }
    */
}
