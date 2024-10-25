using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOut : MonoBehaviour
{
    public MapGen MapGen;


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Top") || col.gameObject.CompareTag("Mid") || col.gameObject.CompareTag("Bot"))
        {
            Destroy(col.gameObject);
            MapGen.CreateMap();
        }
    }
}
