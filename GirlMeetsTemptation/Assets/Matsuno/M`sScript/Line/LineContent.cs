using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineContent : MonoBehaviour
{
    [SerializeField] private RectTransform content;   // Scroll View��Content
    [SerializeField] private GameObject LeftPrefab;    // TextMeshProUGUI��Prefab
    [SerializeField] private GameObject RightPrefab;    // TextMeshProUGUI��Prefab
    [SerializeField] private float padding = 10f;     // �e�v�f�̊Ԋu

    /// <summary>
    /// TextMeshPro�̃e�L�X�g�𓮓I�ɒǉ�����
    /// </summary>
    public void AddToLeftText(string message)
    {
        // TextMeshProUGUI��Prefab��Content�̎q�Ƃ��Đ���
        GameObject newText = Instantiate(LeftPrefab, content);

        // RectTransform�R���|�[�l���g���擾
        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        //if (rectTransform != null)
        //{
        //    // �S�̂̕���600�ɐݒ�
        //    rectTransform.sizeDelta = new Vector2(600, rectTransform.sizeDelta.y);
        //    rectTransform.anchorMin = new Vector2(0, 1); // ����ɑ�����
        //    rectTransform.anchorMax = new Vector2(0, 1);
        //    rectTransform.pivot = new Vector2(0, 1);     // �s�{�b�g������ɑ�����
        //}

        // TextMeshProUGUI�R���|�[�l���g���擾���ăe�L�X�g��ݒ�
        TextMeshProUGUI tmpComponent = newText.GetComponent<TextMeshProUGUI>();
        if (tmpComponent != null)
        {
            tmpComponent.text = message;
            tmpComponent.fontSize = 35;                          // �t�H���g�T�C�Y��ݒ�
            tmpComponent.alignment = TextAlignmentOptions.Left;  // ������
            tmpComponent.enableWordWrapping = true;              // �����ŒP�ꂲ�Ƃɉ��s
            tmpComponent.color = Color.black;

            // �}�[�W���i�]���j���g���ĕ����̕\������400�ɐ���
            float totalWidth = 600f;
            float usableWidth = 400f;
            float marginValue = (totalWidth - usableWidth) / 2;  // ���E�ɋϓ��ȗ]����ݒ�
            tmpComponent.margin = new Vector4(0, 0, marginValue, 0);  // ���E��E�E�E���̏�
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
            // RectTransform��Anchor��Pivot���E�����ɐݒ�
            rectTransform.anchorMin = new Vector2(1, 0.5f);  // �E�[�̒�����Anchor��ݒ�
            rectTransform.anchorMax = new Vector2(1, 0.5f);  // �E�[�̒�����Anchor��ݒ�
            rectTransform.pivot = new Vector2(1, 0.5f);      // Pivot���E�[�̒����ɐݒ�

            // Prefab�̈ʒu�𒲐�
            rectTransform.anchoredPosition = new Vector2(-padding, 0);  // �E�[����padding����������
        }

        // TextMeshProUGUI�R���|�[�l���g���擾���ăe�L�X�g��ݒ�
        TextMeshProUGUI tmpComponent = newText.GetComponent<TextMeshProUGUI>();
        if (tmpComponent != null)
        {
            tmpComponent.text = message;
            tmpComponent.fontSize = 35;  // �t�H���g�T�C�Y��ݒ�
            tmpComponent.alignment = TextAlignmentOptions.Left;  // �e�L�X�g��������
            tmpComponent.color = Color.black;

            // �}�[�W���i�]���j���g���ĕ����̕\������400�ɐ���
            float totalWidth = 600f;
            float usableWidth = 400f;
            float marginValue = (totalWidth - usableWidth) / 2;  // ���E�ɋϓ��ȗ]����ݒ�
            tmpComponent.margin = new Vector4(marginValue, 0, 0, 0);  // ���E��E�E�E���̏�
        }

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