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
            Debug.Log("—‰º1");
            playerCollider = col.gameObject.GetComponent<Collider>();
            // Õ“Ë‚ğˆê“I‚É–³Œø‚É‚·‚é
            Physics.IgnoreCollision(playerCollider, floorCollider, true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("—‰º2");
            playerCollider = col.gameObject.GetComponent<Collider>();
            // Õ“Ë‚ğˆê“I‚É–³Œø‚É‚·‚é
            Physics.IgnoreCollision(playerCollider, floorCollider, true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerCollider = col.gameObject.GetComponent<Collider>();
            // Õ“Ë‚ğˆê“I‚É–³Œø‚É‚·‚é
            Physics.IgnoreCollision(playerCollider, floorCollider, false);
        }
    }
}
