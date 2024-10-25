using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Human") || col.gameObject.CompareTag("Car") || col.gameObject.CompareTag("Meteo"))
        {
            Destroy(col.gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.CompareTag("Human") || col.gameObject.CompareTag("Car") || col.gameObject.CompareTag("Meteo"))
        {
            Destroy(col.gameObject);
        }
    }
}
