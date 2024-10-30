using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{

    int StageSize = 15;
    int StageIndex;

    public Transform Target;//Unitychan
    public GameObject[] stagenum;//ステージのプレハブ
    private int FirstStageIndex = 1;//スタート時にどのインデックスからステージを生成するのか
    public GameObject finalStagePrefab; // 最後に生成されるステージのプレハブ
    private bool FinalStage = false; // 最後のステージが生成されたかどうか
    private int aheadStage = 3; //事前に生成しておくステージ
    public int totalStages; // 生成するステージの総数
    public List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト
    private PlayerMovement PlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        if (FinalStage)
        {
            return; // 最後のステージが生成されたら、それ以上のステージは生成しない
        }
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if(targetPosIndex + aheadStage > StageIndex)
        {
            StageManager(targetPosIndex + aheadStage);
        }
    }
    void StageManager(int maps)
    {
        if(maps <= StageIndex)
        {
            return;
        }

        // ステージの総数を超えないように制限
        int maxMaps = Mathf.Min(maps, FirstStageIndex + totalStages - 1);

        for(int i = StageIndex + 1;i <= maps; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
            // 最後のステージを生成した場合、フラグを立てる
            if (FinalStage)
            {
                break;
            }
        }

        while(StageList.Count > aheadStage + 1)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//ステージを生成する
    {
        // ステージ総数に達したら最後のステージを生成
        if (index == FirstStageIndex + totalStages - 1)
        {
            FinalStage = true;
            return Instantiate(finalStagePrefab, new Vector3(0.96f, 9.73f, index * StageSize), Quaternion.identity);
        }

        int nextStage/* = Random.Range(0, stagenum.Length)*/;

        float rand = Random.Range(0f, 1f); // 0.0 から 1.0 の乱数を取得
        if(PlayerMovement.CheckTime()){
        if (rand < 0.10f) // 10% の確率で stagenum[0]
        {
        nextStage = 0;
        }
        else if (rand < 0.50f) // 40% の確率で stagenum[1]
        {
        nextStage = 1;
        }
        else if (rand < 0.70f) // 20% の確率で stagenum[2]
        {
        nextStage = 2;
        }
        else // 30% の確率で stagenum[3]
        {
        nextStage = 3;
        }
        }else{
        if (rand < 0.20f) // 20% の確率で stagenum[0]
        {
        nextStage = 0;
        }else if (rand < 0.50f) // 30% の確率で stagenum[1]
        {
        nextStage = 1;
        }else if (rand < 0.90f) // 40% の確率で stagenum[2]
        {
        nextStage = 2;
        }else // 10% の確率で stagenum[3]
        {
        nextStage = 3;
        }
        }
        
        GameObject stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }
    
}
