using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayer : MonoBehaviour
{
    [Header("プレイヤー必須設定")]
    public Animator animator;
    public Rigidbody rb;
    public Collider playerCol;

    //プレイヤー入力
    private InputAction MiniJumpAction;
    private InputAction MiniFallAction;
    private InputAction ShotDownAction;
    private InputAction MoveRAction;//右移動ボタンの押下状態
    private InputAction MoveLAction;//左移動ボタンの押下状態



    [Header("移動設定")]
    public float speed;
    public float jumpForce = 5f;
    private bool isGrounded = true;


    [Header("プレイヤー設定")]
    bool isFall = false;
    bool BotFall = true;
    float time = 0f;
    public bool jump;
    public bool fall;
    bool fallOnce = false;


    //床のcollider
    private Collider floorCol;
    private Collider OldFloor;

    void OnEnable()
    {
        
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        MiniJumpAction = actionMap["MiniGameJump"];
        MiniFallAction = actionMap["miniGameFall"];
        ShotDownAction = actionMap["Shutdown"];
        MoveRAction = actionMap["MoveR"];
        MoveLAction = actionMap["MoveL"];

        playerCol.enabled = true;
        isFall = false;
        BotFall = true;
        fallOnce = false;
    }


    void Update()
    {
        //InputSystem用
        bool jump = MiniJumpAction.triggered;
        bool fall = MiniFallAction.triggered;
        bool down = ShotDownAction.triggered;
        bool MoveR = MoveRAction.triggered;
        bool MoveL = MoveLAction.triggered;

        #region メインゲームレーン移動
        // 左への移動
        if ((MoveL || Input.GetKey(KeyCode.Q)) && PlayerMovement.currentLane > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            //PlayerMovement.currentLane--;
            PlayerMovement.instance.MoveToLane();
        }

        // 右への移動
        if ((MoveR || Input.GetKey(KeyCode.E)) && PlayerMovement.currentLane < 2 && !Input.GetKey(KeyCode.LeftShift))
        {
            //PlayerMovement.currentLane++;
            PlayerMovement.instance.MoveToLane();
        }
        #endregion


        #region アプリを閉じる
        //アプリを閉じる
        if (down)
        {
            //ButtonManager.instance.PlayInputSet();
            MiniGameManager.isStart = false;
            MiniGameManager.isOpen = false;
        }
        
        #endregion

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
        float dps_v = Input.GetAxis("D_Pad_V");
        if ((jump || Input.GetKeyDown("w") || dps_v >= 0.9) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false; // ジャンプ中は地面にいないとみなす
            Audio.Instance.SmartPlaySound(0);//ジャンプ音
            Debug.Log("ジャンプ");
            dps_v = 0f;
        }

        if ((fall || Input.GetKeyDown("s") || dps_v <= -0.9) && !fallOnce)
        {
            FallPlayer();
            dps_v = 0f;
        }

        if (isFall && OldFloor != null)
        {
            time += Time.deltaTime;
            if (time > 0.5f)
            {
                Physics.IgnoreCollision(playerCol, OldFloor, false);
                playerCol.enabled = true;
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
            fallOnce = false;
        }

        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            BotFall = false;
            fallOnce = false;
            if (fall)
            {
                isFall = true;
            }
            if (col.gameObject.CompareTag("Bot"))
            {
                BotFall = true;
            }
        }

        if (col.gameObject.CompareTag("GameOver"))
        {
            
            if(0 == MiniGameManager.MiniDeathID)
            {
                MiniGameManager.MiniDeathID = 1;
                Audio.Instance.SmartPlaySound(4);//落下死亡音
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
                isFall = true;
            }
        }
        if (col.gameObject.CompareTag("Bot"))
        {
            BotFall = true;
        }
        if (col.CompareTag("Coin"))
        {
            MiniGameManager.CoinCount++;
            Destroy(col.gameObject);
            Audio.Instance.SmartPlaySound(2);//コイン獲得音
        }
    }
    private void OnCollisionStay(Collision col)
    {
        // 地面に接触した場合、isGroundedをtrueにする
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            BotFall = false;
            if (fall)
            {
                isFall = true;

            }
        }
        if (col.gameObject.CompareTag("Bot"))
        {
            BotFall = true;
        }
    }


    void FallPlayer()
    {
        //
        if (!BotFall && floorCol != null)
        {
            Physics.IgnoreCollision(playerCol, floorCol, true);
            playerCol.enabled = false;
            OldFloor = floorCol;
            isFall = true;
            fallOnce = true;
            Audio.Instance.SmartPlaySound(1);//落ちる音
        }
    }
}
