using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDeleyr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // タグが "player" のオブジェクトに当たった場合
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            
        }
    }
}
