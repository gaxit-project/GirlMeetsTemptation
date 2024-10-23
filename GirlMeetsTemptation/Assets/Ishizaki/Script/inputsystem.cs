using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsystem : MonoBehaviour
{
    private InputAction MoveRAction;//�E�ړ��{�^���̉������
    private InputAction MoveLAction;//���ړ��{�^���̉������
    private InputAction ButtonBAction;//B�{�^���̉������

    // Start is called before the first frame update
    void Start()
    {
        //InputSystem�p
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        MoveRAction = actionMap["MoveR"];
        MoveLAction = actionMap["MoveL"];
        ButtonBAction = actionMap["ButtonB"];
    }

    // Update is called once per frame
    void Update()
    {
        //InputSystem�p
        bool MoveR = MoveRAction.triggered;
        bool MoveL = MoveLAction.triggered;
        bool ButtonB = ButtonBAction.triggered;
        Debug.Log("MR="+MoveR+" ML="+MoveL+" B="+ButtonB);

        if (MoveR && MoveL)
        {
            Debug.Log("��~");
        }
        else if (MoveR)
        {
            Debug.Log("�E�ړ�");
        }
        else if (MoveL)
        {
            Debug.Log("���ړ�");
        }
        if (ButtonB)
        {
            Debug.Log("�{�^��B");
        }
    }
}
