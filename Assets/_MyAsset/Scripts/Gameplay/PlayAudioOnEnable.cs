using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayAudioOnEnable : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string _voiceText;
    [SerializeField] private bool _disableWhenFinish = true;
    private bool _flag;

    void OnEnable()
    {
        AudioManager.Singleton.PlayAudioFromUrl(_voiceText, () =>
        {
            if (_disableWhenFinish)
            {
                this.gameObject.SetActive(false);
            }
        });

        _flag = false;
        StartCoroutine(DelayCoroutine(1));
    }

    IEnumerator DelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        _flag = true;
    }

    void Update()
    {
        if (!_flag)
        {
            return;
        }

        var canPlayNextVoice = InputManager.Singleton.IsLeftHand_TriggerHold || InputManager.Singleton.IsRightHand_TriggerHold;
        if (canPlayNextVoice)
        {
            this.gameObject.SetActive(false);
        }
    }
}