using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    [Header("プレイヤー必須設定")]
    public Animator animator;
    public Rigidbody rb;
    public Collider playerCol;

    [Header("移動設定")]
    public float speed;
    public float jumpForce = 5f;
    private bool isGrounded = true;


    [Header("プレイヤー設定")]
    bool isFall = false;
    float time = 0f;


    //床のcollider
    private Collider floorCol;


    void Start()
    {
        
    }

    void Update()
    {
        // X方向に自動で進む
        //Vector3 move = new Vector3(speed, rb.velocity.y, rb.velocity.z); // 常にspeedの値でX方向に進む
        //rb.velocity = new Vector3(rb.velocity.x * speed, rb.velocity.y, rb.velocity.z); // 速度を設定
        if (MiniGameManager.isStart && 0 == MiniGameManager.MiniDeathID)
        {
            rb.MovePosition(rb.position + new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            rb.MovePosition(rb.position + new Vector3(0, 0, 0));
        }



        animator.SetFloat("Speed", 1);




        // アニメーションの速度を設定
        //float playerSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        //animator.SetFloat("speed", playerSpeed);

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false; // ジャンプ中は地面にいないとみなす
        }

        if (isFall)
        {
            time += Time.deltaTime;
            if (time > 0.6f)
            {
                playerCol.enabled = true;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = false;
                time = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        // 地面に接触した場合、isGroundedをtrueにする
        if (col.gameObject.CompareTag("Bot") || col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            isGrounded = true;
        }

        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown("s"))
            {
                // 衝突を一時的に無効にする
                playerCol.enabled = false; ;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = true;
            }
        }

        if (col.gameObject.CompareTag("GameOver"))
        {
            
            if(0 == MiniGameManager.MiniDeathID)
            {
                MiniGameManager.MiniDeathID = 1;
            }
        }
        if(col.gameObject.CompareTag("Human") || col.gameObject.CompareTag("Car"))
        {
            if (MiniGameManager.islunatic)
            {
                // エネミーの Rigidbody を取得
                Rigidbody EnemyRB = col.gameObject.GetComponent<Rigidbody>();

                if (EnemyRB != null)
                {
                    // 衝突の接触点の法線を取得（衝突方向）
                    Vector3 knockbackDirection = col.contacts[0].normal;

                    // プレイヤーを反対方向に吹っ飛ばす
                    EnemyRB.AddForce(-knockbackDirection * 10f, ForceMode.Impulse);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // 衝突を一時的に無効にする
                playerCol.enabled = false; ;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = true;
            }
        }
    }
    private void OnCollisionStay(Collision col)
    {
        // 地面に接触した場合、isGroundedをtrueにする
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // 衝突を一時的に無効にする
                playerCol.enabled = false;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = true;
            }
        }
    }



}
