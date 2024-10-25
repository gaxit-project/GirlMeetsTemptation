using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineContent : MonoBehaviour
{
    [SerializeField] private RectTransform content;   // Scroll View��Content
    [SerializeField] private GameObject LeftPrefab;    // TextMeshProUGUI��Prefab
    [SerializeField] private GameObject RightPrefab;    // TextMeshProUGUI��Prefab
    [SerializeField] private float padding = 10f;     // �e�v�f�̊Ԋu

    const int DIGIT = 14;

    /// <summary>
    /// TextMeshPro�̃e�L�X�g�𓮓I�ɒǉ�����
    /// </summary>
    public void AddToLeftText(string message)
    {
        // TextMeshProUGUI��Prefab��Content�̎q�Ƃ��Đ���
        GameObject newText = Instantiate(LeftPrefab, content);

        // RectTransform�R���|�[�l���g���擾
        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // �S�̂̕���600�ɐݒ�
            rectTransform.sizeDelta = new Vector2(600, rectTransform.sizeDelta.y);
            rectTransform.anchorMin = new Vector2(0.1f, -1); // ���ɑ�����
            rectTransform.anchorMax = new Vector2(0.1f, -1);
            rectTransform.pivot = new Vector2(0.1f, 1);     // �s�{�b�g�����ɑ�����
            rectTransform.anchoredPosition = new Vector2(0, rectTransform.anchoredPosition.y);
        }

        Image ImageComponent = newText.GetComponent<Image>();
        ImageComponent.color = new Color(0,0,0);

        string newChat = "";

        while (DIGIT < message.Length)
        {
            //�O14�s�̔����o��
            newChat += message.Substring(0, DIGIT) + "\n";

            //��̕������i�[
            message = message.Substring(DIGIT);
        }

        // TextMeshProUGUI�R���|�[�l���g���擾���ăe�L�X�g��ݒ�
        TextMeshProUGUI tmpComponent = newText.GetComponentInChildren<TextMeshProUGUI>();
        if (tmpComponent != null)
        {
            tmpComponent.text = newChat + message;
            tmpComponent.fontSize = 35;                          // �t�H���g�T�C�Y��ݒ�
            tmpComponent.alignment = TextAlignmentOptions.Left;  // ������
            tmpComponent.enableWordWrapping = true;              // �����ŒP�ꂲ�Ƃɉ��s
            tmpComponent.color = Color.white;
        }

        // ���C�A�E�g�̍X�V
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }


    public void AddToRightText(string message)
    {
        // TextMeshProUGUI��Prefab��Content�̎q�Ƃ��Đ���
        GameObject newText = Instantiate(RightPrefab, content);

        // RectTransform�R���|�[�l���g���擾
        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            //RectTransform��Anchor��Pivot���E�����ɐݒ�
            rectTransform.anchorMin = new Vector2(1, 0.5f);  // �E�[�̒�����Anchor��ݒ�
            rectTransform.anchorMax = new Vector2(1, 0.5f);  // �E�[�̒�����Anchor��ݒ�
            rectTransform.pivot = new Vector2(0.9f, 0.5f);      // Pivot���E�[�̒����ɐݒ�
            // Prefab�̈ʒu�𒲐�
            rectTransform.anchoredPosition = new Vector2(-padding, 0);  // �E�[����padding����������
        }

        Image ImageComponent = newText.GetComponent<Image>();
        ImageComponent.color = new Color(150f / 255f, 230f / 255f, 150f / 255f);

        string newChat = "";

        while (DIGIT < message.Length)
        {
            //�O14�s�̔����o��
            newChat += message.Substring(0, DIGIT) + "\n";

            //��̕������i�[
            message = message.Substring(DIGIT);
        }

        // TextMeshProUGUI�R���|�[�l���g���擾���ăe�L�X�g��ݒ�
        TextMeshProUGUI tmpComponent = newText.GetComponentInChildren<TextMeshProUGUI>();

        if (tmpComponent != null)
        {
            tmpComponent.text = newChat + message;
            tmpComponent.fontSize = 35;  // �t�H���g�T�C�Y��ݒ�
            tmpComponent.alignment = TextAlignmentOptions.Left;  // �e�L�X�g��������
            tmpComponent.color = Color.black;
        }

        // �摜
        int NumberChar = message.Length / 14;   //�s��

        // ���C�A�E�g�̍X�V
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }
    public void RemoveLastText()
    {
        // �q�I�u�W�F�N�g�����邩�m�F
        if (content.childCount > 0)
        {
            // �Ō�̎q�I�u�W�F�N�g���擾
            Transform lastChild = content.GetChild(content.childCount - 1);

            // �I�u�W�F�N�g���폜
            Destroy(lastChild.gameObject);

            // ���C�A�E�g�̍č\�z������
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }
        else
        {
            Debug.Log("Content�ɍ폜����v�f������܂���B");
        }
    }




}