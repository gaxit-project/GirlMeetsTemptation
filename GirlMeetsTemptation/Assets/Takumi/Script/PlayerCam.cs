using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("プレイヤー")]
    public Transform Player;

    private Vector3 offset; // 初期位置との差を保持


    void Start()
    {
        // カメラとプレイヤーの初期位置の差を計算
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのx座標に追従し、yとzはそのまま維持
        transform.position = new Vector3(Player.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
