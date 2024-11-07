using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoLayout : BaseLayout
{
    [SerializeField] private List<Image> _stars;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _playButton;
    private int _mapLevelId = -1;

    void Start()
    {
        _closeButton.onClick.AddListener(() =>
        {
            CloseLayout();
        });

        _playButton.onClick.AddListener(() =>
        {
            Debug.Log("[DEV] _playButton clicked!!!");
            OpenSceneAdditive();
        });

        FillStars(2.2f);
    }

    void OpenSceneAdditive()
    {
        string sceneName = $"Level{_mapLevelId}Scene";
        try
        {
            Loader.LoadSceneAdditive(sceneName);
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
        }

        // string sceneName = $"Level{_mapLevelId}Scene";
        // if (Enum.TryParse(sceneName, out ESceneNames scene))
        // {
        //     Loader.LoadSceneAdditive(scene);
        // }
        // else
        // {
        //     Debug.Log("[DEV, ERROR] Can not convert sceneName to Enum");
        // }
    }

    void FillStars(float point)
    {
        int lowerIntNumber = Mathf.FloorToInt(point);
        _stars.ForEach(star => star.fillAmount = 0);
        for (int p = 1; p <= lowerIntNumber; p++)
        {
            _stars[p - 1].fillAmount = 1;
        }
        _stars[lowerIntNumber].fillAmount = point - lowerIntNumber;
    }

    [Obsolete]
    public new void OpenLayout() { }

    public void OpenLayout(int mapLevelId, string levelName, float point)
    {
        base.OpenLayout();

        Layout.transform.DOScale(Vector3.one, .4f);

        _mapLevelId = mapLevelId;
        _titleText.text = $"{mapLevelId}\n{levelName}";
        FillStars(point);
    }

    public override void CloseLayout()
    {
        Layout.transform.DOScale(Vector3.zero, .4f)
        .OnComplete(() => base.CloseLayout());
    }
}