using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpotifyOnOff : MonoBehaviour
{
    public SpotifyManager targetScript; // 制御するスクリプト
    public Button toggleButton; // トグル用ボタン
    private PlayerMovement PlayerMovement;

    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        // ボタンにリスナーを追加
        toggleButton.onClick.AddListener(ToggleTargetScript);
    }
    void Update(){
        toggleButton.onClick.AddListener(ToggleTargetScript);
        if(!PlayerMovement.getphoneOn()){
            targetScript.enabled = false;
        }
    }

    private void ToggleTargetScript()
    {
        // TargetScriptの有効/無効を切り替える
        if (targetScript != null)
        {
            if(PlayerMovement.getphoneOn()){
                targetScript.enabled = true;
            }else{
                targetScript.enabled = false;
            }
        }
        
    }
}
