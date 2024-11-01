using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public bool enemy = true;
    public float knockbackForce = 10f;  // 吹っ飛ばす力
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.Rotate(0, -90f, 0);
    }

    void Update()
    {
        if (enemy)
        {
            //rb.velocity = new Vector3(rb.velocity.x * -5, rb.velocity.y, rb.velocity.z); // 速度を設定
            rb.MovePosition(rb.position + new Vector3(-1.5f * Time.deltaTime, 0, 0));
        }
        else
        {
            //rb.velocity = new Vector3(rb.velocity.x * -8, rb.velocity.y, rb.velocity.z); // 速度を設定
            rb.MovePosition(rb.position + new Vector3(-3 * Time.deltaTime, 0, 0));
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (enemy)
        {
            //
            if (col.gameObject.CompareTag("Player"))
            {
                Audio.Instance.SmartPlaySound(3);//人とぶつかり音
                if (!MiniGameManager.islunatic)//Not狂乱時
                {
                    // プレイヤーの Rigidbody を取得
                    Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();

                    if (playerRB != null)
                    {
                        // 衝突の接触点の法線を取得（衝突方向）
                        Vector3 knockbackDirection = col.contacts[0].normal;

                        // プレイヤーを反対方向に吹っ飛ばす
                        playerRB.AddForce(-knockbackDirection * knockbackForce, ForceMode.Impulse);
                    }
                }
            }

        }
        else
        {
            //
            if (col.gameObject.CompareTag("Player"))
            {
                if (!MiniGameManager.islunatic)//Not狂乱時
                {
                    if (0 == MiniGameManager.MiniDeathID)
                    {
                        MiniGameManager.MiniDeathID = 2;
                        Audio.Instance.SmartPlaySound(5);//車とぶつかる音
                    }
                    Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();

                    if (playerRB != null)
                    {
                        // 衝突の接触点の法線を取得（衝突方向）
                        Vector3 knockbackDirection = col.contacts[0].normal;

                        // プレイヤーを反対方向に吹っ飛ばす
                        playerRB.AddForce(-knockbackDirection * knockbackForce, ForceMode.Impulse);
                    }
                }
            }
            if (col.gameObject.CompareTag("Human"))
            {
                Destroy(col.gameObject);
            }

        }
    }

}
