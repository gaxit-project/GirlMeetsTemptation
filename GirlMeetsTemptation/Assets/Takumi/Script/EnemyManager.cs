using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy生成プレハブ")]
    public GameObject HumanObj;
    public GameObject CarObj;

    [Header("レーン位置")]
    public Transform TopPos;
    public Transform MidPos;
    public Transform BotPos;
    public float Top;
    public float Mid;
    public float Bot;

    private float HumanTime;
    private float CarTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MiniGameManager.isStart && MiniGameManager.isOpen)
        {
            HumanTime += Time.deltaTime;
            CarTime += Time.deltaTime;
            if (HumanTime > 4f)
            {
                HumanGenrate();
                HumanTime = 0f;
            }
            if (CarTime > 5f)
            {
                CarGenrate();
                CarTime = 0f;
            }
        }
    }

    void HumanGenrate()
    {
        int rnd = Random.Range(0, 10);
        int rnd1 = Random.Range(-3, 3);
        int rnd2 = Random.Range(-3, 3);
        int rnd3 = Random.Range(-3, 3);
        if (rnd > 6)
        {
            Instantiate(HumanObj, new Vector3(transform.position.x + rnd1, TopPos.position.y, 0f), Quaternion.identity);
            Instantiate(HumanObj, new Vector3(transform.position.x + rnd2, MidPos.position.y, 0f), Quaternion.identity);
        }
        else if (rnd > 3)
        {
            Instantiate(HumanObj, new Vector3(transform.position.x + rnd1, TopPos.position.y, 0f), Quaternion.identity);
            Instantiate(HumanObj, new Vector3(transform.position.x + rnd3, BotPos.position.y, 0f), Quaternion.identity);
        }
        else if (rnd >= 0)
        {
            Instantiate(HumanObj, new Vector3(transform.position.x + rnd2, MidPos.position.y, 0f), Quaternion.identity);
            Instantiate(HumanObj, new Vector3(transform.position.x + rnd3, BotPos.position.y, 0f), Quaternion.identity);
        }


    }
    void CarGenrate()
    {
        int rnd = Random.Range(0, 10);

        if(rnd > 6)
        {
            //
            Instantiate(CarObj, new Vector3(transform.position.x, TopPos.position.y, 0f), Quaternion.identity);
        }
        else if(rnd > 3)
        {
            Instantiate(CarObj, new Vector3(transform.position.x, MidPos.position.y, 0f), Quaternion.identity);
        }
        else if(rnd >= 0)
        {
            Instantiate(CarObj, new Vector3(transform.position.x, BotPos.position.y, 0f), Quaternion.identity);
        }
    }
}
