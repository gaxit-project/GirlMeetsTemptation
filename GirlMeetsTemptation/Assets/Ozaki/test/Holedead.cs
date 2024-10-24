using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holedead : MonoBehaviour
{
    // Start is called before the first frame update
    private bool holed = false;
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
            holed = true;
            // Scene の EndGame メソッドを呼び出す
            Scene.GetInstance().EndGame();
        }
    }

    public bool getHoled(){
        return holed;
    }
}
