using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    /*
    [Header("�v���C���[")]
    public Transform Player;

    private Vector3 offset; // �����ʒu�Ƃ̍���ێ�

    public Collider playerCol;
    public Collider floorCol;

    bool isFall = false;

    float time = 0f;

    void Start()
    {
        // �J�����ƃv���C���[�̏����ʒu�̍����v�Z
        offset = transform.position - Player.position;
    }


    private void Update()
    {
        // �v���C���[��x���W�ɒǏ]���Ay��z�͂��̂܂܈ێ�
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
            Debug.Log("��");
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown("D"))
            {
                Debug.Log("���蔲��");
                // �Փ˂��ꎞ�I�ɖ����ɂ���
                playerCol.enabled = false; ;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                //isFall = true;
            }
        }
    }
    private void OnTriggerStay(Collider col)
    {
        // �n�ʂɐڐG�����ꍇ�AisGrounded��true�ɂ���
        if (col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Top"))
        {
            Debug.Log("��");
            floorCol = col.gameObject.GetComponent<Collider>();
            if (Input.GetKeyDown("d"))
            {
                Debug.Log("���蔲��");
                // �Փ˂��ꎞ�I�ɖ����ɂ���
                playerCol.enabled = false;
                //Physics.IgnoreCollision(playerCol, floorCol, true);
                //isFall = true;
            }
        }
    }
    */
}
