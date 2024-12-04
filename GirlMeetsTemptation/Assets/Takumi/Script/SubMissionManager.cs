using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMissionManager : MonoBehaviour
{
    public static int CoinSum;
    public static float DistanceSum;

    public Text SubMissionText;


    public static SubMissionManager instance;
    void OnEnable()
    {
        MiniGameManager.SubClear = false;
        if(MiniGameManager.SubMissionID == 1)
        {
            //コインの枚数
            CoinSum = Random.Range(3, 6);
        }
        else if(MiniGameManager.SubMissionID == 2)
        {
            //走る距離
            DistanceSum = Random.Range(30f, 60f);
        }
    }


    void Update()
    {
        //デバッグ用
        if(Input.GetKeyDown("o"))
        {
            MiniGameManager.CoinCount++;
        }





        if (MiniGameManager.SubMissionID == 0)//サブミッション無し
        {
            SubMissionText.text = "";
        }
        else if (MiniGameManager.SubMissionID == 1)//コイン獲得ミッション
        {
            SubMissionText.text = "コイン : " + MiniGameManager.CoinCount + " / " + CoinSum;
            if (MiniGameManager.CoinCount >= CoinSum)
            {
                MiniGameManager.SubClear = true;
                SubMissionText.text = "ミッション\n達成";
            }
        }
        else if(MiniGameManager.SubMissionID == 2)//走る距離ミッション
        {

        }
    }
}
