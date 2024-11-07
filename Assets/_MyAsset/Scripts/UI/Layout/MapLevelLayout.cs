using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MapLevelLayout : BaseLayout
{
    [SerializeField] private GameObject _levelButtonContainer;
    [SerializeField] private TMP_Text _timeText;

    private List<LevelButton> _levelButtons = new();


    void Start()
    {
        foreach (Transform levelButton in _levelButtonContainer.transform)
        {
            _levelButtons.Add(levelButton.GetComponent<LevelButton>());
        }

        InactiveAllLevelButton();
        ActiveFromFirstToSpecifyIndexLevelButtons(3);

        // var parent = Layout.transform.parent;
        // var scale = parent.localScale;
        // parent.localScale = new Vector3(0, scale.y, scale.z);
        // parent.DOScaleX(scale.x, .8f);
    }

    void FixedUpdate()
    {
        _timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void InactiveAllLevelButton()
    {
        _levelButtons.ForEach(item => item.SetObscure());
    }

    public void ActiveFromFirstToSpecifyIndexLevelButtons(float toIndex)
    {
        for (int i = 0; i <= toIndex; i++)
        {
            _levelButtons[i].SetHighlight();
        }
    }
}