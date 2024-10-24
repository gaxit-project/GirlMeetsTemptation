using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcrash : MonoBehaviour
{
    public GameObject Car;

    private bool isMoving = false; // Car が動いているかを管理するフラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // isMoving が true の間、Car の x 座標を動かす
        if (isMoving)
        {
            Car.transform.position += new Vector3(-4f * Time.deltaTime, 0, 0); // x方向に移動
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // タグが "Player" のオブジェクトに当たった場合
        if (other.CompareTag("Player"))
        {
            isMoving = true; // 車の移動を開始
            Audio.GetInstance().PlaySound(4);
        }
    }
    void OnTriggerExit(Collider other)
    {
        // タグが "Player" のオブジェクトに離れた場合
        if (other.CompareTag("Player"))
        {
            isMoving = false; // 車の移動を開始
            Destroy(Car);
        }
    }
}
