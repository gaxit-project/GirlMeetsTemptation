using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlamMoveScript : MonoBehaviour
{
    float speed = 5;

    void Update()
    {
    this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
