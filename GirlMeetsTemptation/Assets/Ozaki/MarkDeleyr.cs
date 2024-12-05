using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDeleyr : MonoBehaviour
{
    public bool holed = false;
    private PlayerMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        holed = false;
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
            Audio.GetInstance().PlaySound(13);
            PlayerMovement.enabled = false;
            holed = true;
            Destroy(this.gameObject);
            
        }
    }
}
