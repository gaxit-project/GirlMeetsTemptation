using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoDestroy : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        float rnd = Random.Range(-3f, 3f);
        rb.velocity = new Vector3(rb.velocity.x * rnd , rb.velocity.y, rb.velocity.z); // ë¨ìxÇê›íË
    }

    private void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Top") || col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Bot"))
        {
            Destroy(col.gameObject);
        }

    }
}
