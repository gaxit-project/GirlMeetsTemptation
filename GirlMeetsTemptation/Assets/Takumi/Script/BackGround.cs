using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField, Header("éãç∑å¯â "), Range(0, 1)]
    private float _parallaxEffect;

    public GameObject _camera;
    private float _length;
    private float _startPosX;

    void Start()
    {
        _startPosX = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _Parallax();
    }
    private void _Parallax()
    {
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        float dist = _camera.transform.position.x * _parallaxEffect;


        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        if (temp > _startPosX + _length)
        {
            _startPosX += _length;
        }
        else if(temp < _startPosX - _length)
        {
            _startPosX -= _length;
        }



    }
}
