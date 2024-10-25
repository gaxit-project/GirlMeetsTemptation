using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("�v���C���[")]
    public Transform Player;

    private Vector3 offset; // �����ʒu�Ƃ̍���ێ�


    void Start()
    {
        // �J�����ƃv���C���[�̏����ʒu�̍����v�Z
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[��x���W�ɒǏ]���Ay��z�͂��̂܂܈ێ�
        transform.position = new Vector3(Player.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
