using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passengermove : MonoBehaviour
{
    private bool crash = false;
    private bool hasPlayedCrashSound = false; // サウンド再生管理用フラグ
    private float moveSpeed = 0.1f;
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

            // サウンド再生フラグをリセット
            hasPlayedCrashSound = false;
        }
        else
        {
            animator.SetBool("walking", false);
            rb.constraints = RigidbodyConstraints.FreezePositionZ;

            // サウンドが再生されていない場合のみ再生
            if (!hasPlayedCrashSound)
            {
                Audio.GetInstance().PlaySound(2);
                hasPlayedCrashSound = true;  // 再生済みフラグを設定
                StartCoroutine(PlaySecondSoundWithDelay(1f));
            }
        }
    }
    IEnumerator PlaySecondSoundWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);  // 指定時間待機
        Audio.GetInstance().PlaySound(3);  // 次のサウンドを再生
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
