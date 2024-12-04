using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFallFloor : MonoBehaviour
{
    public Collider playerCollider;
    public Collider floorCollider;




    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("����1");
            playerCollider = col.gameObject.GetComponent<Collider>();
            // �Փ˂��ꎞ�I�ɖ����ɂ���
            Physics.IgnoreCollision(playerCollider, floorCollider, true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("����2");
            playerCollider = col.gameObject.GetComponent<Collider>();
            // �Փ˂��ꎞ�I�ɖ����ɂ���
            Physics.IgnoreCollision(playerCollider, floorCollider, true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerCollider = col.gameObject.GetComponent<Collider>();
            // �Փ˂��ꎞ�I�ɖ����ɂ���
            Physics.IgnoreCollision(playerCollider, floorCollider, false);
        }
    }
}
