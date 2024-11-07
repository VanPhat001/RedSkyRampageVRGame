using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _mapLevelId = -1;
    private Button _button;
    private Image _image;
    private readonly float HIGHLIGHT_THRESHOLD = 1f;
    private readonly float OBSCURE_THRESHOLD = 50f / 255;

    void Awake()
    {
        _button = this.GetComponent<Button>();
        _image = this.GetComponent<Image>();
    }

    void Start()
    {
        _button.onClick.AddListener(() =>
        {
            Debug.Log("[DEV] Level button id " + _mapLevelId + " clicked");
            MapLevelSceneUIManager.Singleton.LevelInfoLayout.OpenLayout(_mapLevelId, "name abc", 1.2f);
        });
    }

    public void SetHighlight()
    {
        _button.interactable = true;
        UpdateImageColor(HIGHLIGHT_THRESHOLD);
    }

    public void SetObscure()
    {
        _button.interactable = false;
        UpdateImageColor(OBSCURE_THRESHOLD);
    }

    private void UpdateImageColor(float alpha)
    {
        Color c = _image.color;
        c.a = alpha;
        _image.color = c;
    }
}