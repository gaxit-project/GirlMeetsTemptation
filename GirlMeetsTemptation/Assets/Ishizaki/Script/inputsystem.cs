using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsystem : MonoBehaviour
{
    private InputAction MoveRAction;//右移動ボタンの押下状態
    private InputAction MoveLAction;//左移動ボタンの押下状態
    private InputAction ButtonBAction;//Bボタンの押下状態

    // Start is called before the first frame update
    void Start()
    {
        //InputSystem用
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        MoveRAction = actionMap["MoveR"];
        MoveLAction = actionMap["MoveL"];
        ButtonBAction = actionMap["ButtonB"];
    }

    // Update is called once per frame
    void Update()
    {
        //InputSystem用
        bool MoveR = MoveRAction.triggered;
        bool MoveL = MoveLAction.triggered;
        bool ButtonB = ButtonBAction.triggered;
        Debug.Log("MR="+MoveR+" ML="+MoveL+" B="+ButtonB);

        if (MoveR && MoveL)
        {
            Debug.Log("停止");
        }
        else if (MoveR)
        {
            Debug.Log("右移動");
        }
        else if (MoveL)
        {
            Debug.Log("左移動");
        }
        if (ButtonB)
        {
            Debug.Log("ボタンB");
        }
    }
}
