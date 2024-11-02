using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayer : MonoBehaviour
{
    [Header("�v���C���[�K�{�ݒ�")]
    public Animator animator;
    public Rigidbody rb;
    public Collider playerCol;

    //�v���C���[����
    private InputAction MiniJumpAction;
    private InputAction MiniFallAction;
    private InputAction ShotDownAction;
    private InputAction MoveRAction;//�E�ړ��{�^���̉������
    private InputAction MoveLAction;//���ړ��{�^���̉������



    [Header("�ړ��ݒ�")]
    public float speed;
    public float jumpForce = 5f;
    private bool isGrounded = true;


    [Header("�v���C���[�ݒ�")]
    bool isFall = false;
    float time = 0f;
    public bool jump;
    public bool fall;


    //����collider
    private Collider floorCol;

    void OnEnable()
    {
        
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        MiniJumpAction = actionMap["MiniGameJump"];
        MiniFallAction = actionMap["miniGameFall"];
        ShotDownAction = actionMap["Shutdown"];
        MoveRAction = actionMap["MoveR"];
        MoveLAction = actionMap["MoveL"];
        
    }


    void Update()
    {
        //InputSystem�p
        bool jump = MiniJumpAction.triggered;
        bool fall = MiniFallAction.triggered;
        bool down = ShotDownAction.triggered;
        bool MoveR = MoveRAction.triggered;
        bool MoveL = MoveLAction.triggered;

        #region ���C���Q�[�����[���ړ�
        // ���ւ̈ړ�
        if (MoveL && PlayerMovement.currentLane > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            //PlayerMovement.currentLane--;
            PlayerMovement.instance.MoveToLane();
        }

        // �E�ւ̈ړ�
        if (MoveR && PlayerMovement.currentLane < 2 && !Input.GetKey(KeyCode.LeftShift))
        {
            //PlayerMovement.currentLane++;
            PlayerMovement.instance.MoveToLane();
        }
        #endregion


        #region �A�v�������
        //�A�v�������
        if (down)
        {
            //ButtonManager.instance.PlayInputSet();
            MiniGameManager.isOpen = false;
        }
        #endregion

        // X�����Ɏ����Ői��
        //Vector3 move = new Vector3(speed, rb.velocity.y, rb.velocity.z); // ���speed�̒l��X�����ɐi��
        //rb.velocity = new Vector3(rb.velocity.x * speed, rb.velocity.y, rb.velocity.z); // ���x��ݒ�
        if (MiniGameManager.isStart && 0 == MiniGameManager.MiniDeathID)
        {
            rb.MovePosition(rb.position + new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            rb.MovePosition(rb.position + new Vector3(0, 0, 0));
        }



        animator.SetFloat("Speed", 1);




        // �A�j���[�V�����̑��x��ݒ�
        //float playerSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        //animator.SetFloat("speed", playerSpeed);

        // �W�����v
        if (jump && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false; // �W�����v���͒n�ʂɂ��Ȃ��Ƃ݂Ȃ�
            Audio.Instance.SmartPlaySound(0);//�W�����v��
            Debug.Log("�W�����v");
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
        // �n�ʂɐڐG�����ꍇ�AisGrounded��true�ɂ���
        if (col.gameObject.CompareTag("Bot") || col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            isGrounded = true;
        }

        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            if (fall)
            {
                // �Փ˂��ꎞ�I�ɖ����ɂ���
                playerCol.enabled = false; ;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = true;
                Audio.Instance.SmartPlaySound(1);//�����鉹
            }
        }

        if (col.gameObject.CompareTag("GameOver"))
        {
            
            if(0 == MiniGameManager.MiniDeathID)
            {
                MiniGameManager.MiniDeathID = 1;
                Audio.Instance.SmartPlaySound(4);//�������S��
            }
        }
        if(col.gameObject.CompareTag("Human") || col.gameObject.CompareTag("Car"))
        {
            if (MiniGameManager.islunatic)
            {
                // �G�l�~�[�� Rigidbody ���擾
                Rigidbody EnemyRB = col.gameObject.GetComponent<Rigidbody>();

                if (EnemyRB != null)
                {
                    // �Փ˂̐ڐG�_�̖@�����擾�i�Փ˕����j
                    Vector3 knockbackDirection = col.contacts[0].normal;

                    // �v���C���[�𔽑Ε����ɐ�����΂�
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
                // �Փ˂��ꎞ�I�ɖ����ɂ���
                playerCol.enabled = false; ;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = true;
            }
        }
        if (col.CompareTag("Coin"))
        {
            MiniGameManager.CoinCount++;
            Destroy(col.gameObject);
            Audio.Instance.SmartPlaySound(2);//�R�C���l����
        }
    }
    private void OnCollisionStay(Collision col)
    {
        // �n�ʂɐڐG�����ꍇ�AisGrounded��true�ɂ���
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            floorCol = col.gameObject.GetComponent<Collider>();
            if (fall)
            {
                // �Փ˂��ꎞ�I�ɖ����ɂ���
                playerCol.enabled = false;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                isFall = true;
                Audio.Instance.SmartPlaySound(1);//�����鉹
            }
        }
    }



}
