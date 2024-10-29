using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMProController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Image frame;

    void Update()
    {
        // ���̓T�C�Y
        var size = new Vector2(textMesh.preferredWidth, textMesh.preferredHeight);
        // �]��
        var border = frame.sprite.border;
        var borderSize = new Vector2(border.x + border.z, border.y + border.w);
        frame.rectTransform.sizeDelta = size + borderSize;

        textMesh.rectTransform.sizeDelta = size;
    }
}