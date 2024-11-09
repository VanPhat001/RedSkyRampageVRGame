using UnityEngine;

public class PlayAudioOnEnable : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string _voiceText;

    void OnEnable()
    {
        AudioManager.Singleton.PlayAudioFromUrl(_voiceText);
    }
}