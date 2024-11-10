using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayAudioOnEnable : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string _voiceText;

    void OnEnable()
    {
        AudioManager.Singleton.PlayAudioFromUrl(_voiceText, () => {
            this.gameObject.SetActive(false);
        });
    }
}