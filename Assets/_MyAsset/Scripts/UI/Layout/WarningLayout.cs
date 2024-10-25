using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningLayout : BaseLayout
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _contentText;
    [SerializeField] private Button _confirmButton;

    void Start()
    {
        _confirmButton.onClick.AddListener(() => CloseLayout());
    }

    [Obsolete("dont use this function", true)]
    public override void OpenLayout()
    {
        base.OpenLayout();
    }

    public void OpenLayout(string title, string content)
    {
        _titleText.text = title;
        _contentText.text = content;
        base.OpenLayout();
    }
}