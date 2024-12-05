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
            if(gameObject.name == "Cleareria")
            {
                Scene.GetInstance().ClearGame();
            }
            else
            {
            holed = true;
           string message;
            switch (gameObject.name)
            {
                case "hole":
                
                    message = "穴に落ちて死んだ";
                    break;
                case "Car":
                Audio.GetInstance().PlaySound(14);
                    message = "車に轢かれて死んだ";
                    break;
                default:
                    message = "";
                    break;
            }

            // GameOver にメッセージを設定して、EndGame メソッドを呼び出す
            MGameOver.SetMessage(message);
            Scene.GetInstance().EndGame();
            }
        }
    }

    public bool getHoled(){
        return holed;
    }
}
