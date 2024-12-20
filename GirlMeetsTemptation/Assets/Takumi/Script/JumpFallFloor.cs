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
            Debug.Log("落下1");
            playerCollider = col.gameObject.GetComponent<Collider>();
            // 衝突を一時的に無効にする
            Physics.IgnoreCollision(playerCollider, floorCollider, true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("落下2");
            playerCollider = col.gameObject.GetComponent<Collider>();
            // 衝突を一時的に無効にする
            Physics.IgnoreCollision(playerCollider, floorCollider, true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerCollider = col.gameObject.GetComponent<Collider>();
            // 衝突を一時的に無効にする
            Physics.IgnoreCollision(playerCollider, floorCollider, false);
        }
    }
}
