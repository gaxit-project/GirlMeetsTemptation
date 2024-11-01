using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public bool enemy = true;
    public float knockbackForce = 10f;  // ������΂���
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.Rotate(0, -90f, 0);
    }

    void Update()
    {
        if (enemy)
        {
            //rb.velocity = new Vector3(rb.velocity.x * -5, rb.velocity.y, rb.velocity.z); // ���x��ݒ�
            rb.MovePosition(rb.position + new Vector3(-1.5f * Time.deltaTime, 0, 0));
        }
        else
        {
            //rb.velocity = new Vector3(rb.velocity.x * -8, rb.velocity.y, rb.velocity.z); // ���x��ݒ�
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
                Audio.Instance.SmartPlaySound(3);//�l�ƂԂ��艹
                if (!MiniGameManager.islunatic)//Not������
                {
                    // �v���C���[�� Rigidbody ���擾
                    Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();

                    if (playerRB != null)
                    {
                        // �Փ˂̐ڐG�_�̖@�����擾�i�Փ˕����j
                        Vector3 knockbackDirection = col.contacts[0].normal;

                        // �v���C���[�𔽑Ε����ɐ�����΂�
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
                if (!MiniGameManager.islunatic)//Not������
                {
                    if (0 == MiniGameManager.MiniDeathID)
                    {
                        MiniGameManager.MiniDeathID = 2;
                        Audio.Instance.SmartPlaySound(5);//�ԂƂԂ��鉹
                    }
                    Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();

                    if (playerRB != null)
                    {
                        // �Փ˂̐ڐG�_�̖@�����擾�i�Փ˕����j
                        Vector3 knockbackDirection = col.contacts[0].normal;

                        // �v���C���[�𔽑Ε����ɐ�����΂�
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
