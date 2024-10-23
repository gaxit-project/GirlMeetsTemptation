using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passengermove : MonoBehaviour
{
    private bool crash = false;
    private float moveSpeed = 0.2f;
    private Animator animator;
    private Rigidbody rb;
    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!crash)
        {
            // 前進
            animator.SetBool("walking", true);
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            moveSpeed += Time.deltaTime * 0.01f;
            rb.constraints = RigidbodyConstraints.None;
        }else{
            animator.SetBool("walking", false);
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // タグが "player" のオブジェクトに当たった場合
        if (other.CompareTag("Player"))
        {
            crash = true;
            col.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crash = false;
        }
    }
}
