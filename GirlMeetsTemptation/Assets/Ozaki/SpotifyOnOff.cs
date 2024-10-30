using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotifyOnOff : MonoBehaviour
{
    public SpotifyManager targetScript; // 制御するスクリプト
    public ButtonManager ButtonManager;
    public Button toggleButton; // トグル用ボタン
    public Button[] phoneBut;
    private PlayerMovement PlayerMovement;

    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();

        // ボタンにリスナーを追加
        toggleButton.onClick.AddListener(ToggleTargetScript);
    }

    void Update()
    {
        // PlayerMovementが取得している状態によってtargetScriptを無効化
        if (!PlayerMovement.getphoneOn())
        {
            targetScript.enabled = false;
            // phoneBut 配列内のボタンを有効にする
                for (int i = 0; i < phoneBut.Length; i++)
                {
                    phoneBut[i].gameObject.SetActive(true);
                }
        }
    }

    private void ToggleTargetScript()
    {
        // TargetScriptの有効/無効を切り替える
        if (targetScript != null)
        {
            if (PlayerMovement.getphoneOn())
            {
                targetScript.enabled = true;

                // phoneBut 配列内のボタンを無効にする
                for (int i = 0; i < phoneBut.Length; i++)
                {
                    phoneBut[i].gameObject.SetActive(false);
                }
            }
            else
            {
                
            }
        }
    }
}
