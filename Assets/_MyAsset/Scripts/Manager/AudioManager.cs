using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton { get; private set; }

    [SerializeField] private AudioSource _audioSource;

    void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        // var audioSource = this.AddComponent<AudioSource>();
        // string text = @"The Adventure Puzzle Kit is a complete template for implementing all 14 unique puzzle assets within one single system. ";
        // GetAudioFromURL(text, audioClip => audioSource.PlayOneShot(audioClip));
    }

    public void PlayAudioFromUrl(string voiceText, Action onPlayEnd)
    {
        GetAudioFromURL(voiceText, audioClip =>
        {
            // _audioSource.PlayOneShot(audioClip);
            StartCoroutine(PlayAudioCoroutine(audioClip, onPlayEnd));
        });

        IEnumerator PlayAudioCoroutine(AudioClip audioClip, Action onPlayEnd)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
            yield return new WaitForEndOfFrame();
            yield return new WaitUntil(() => _audioSource.time >= _audioSource.clip.length);
            onPlayEnd?.Invoke();
        }
    }

    public void GetAudioFromURL(string voiceText, Action<AudioClip> onComplete)
    {
        string[] voices = new[] { "Rose", "Clara", "Emma", "Mason" };

        string apiKey = "9891da074cc541d78b2482de283740f0";
        string lang = "en-ca";
        string voice = voices[0];
        string url = $"https://api.voicerss.org/?key={apiKey}&hl={lang}&v={voice}&src={voiceText}";

        StartCoroutine(GetAudioFromURLCoroutine(url, onComplete));
    }


    private IEnumerator GetAudioFromURLCoroutine(string url, Action<AudioClip> onComplete, AudioType audioType = AudioType.WAV)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, audioType))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("[DEV, ERROR] " + www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                onComplete?.Invoke(myClip);
            }
        }
    }
}