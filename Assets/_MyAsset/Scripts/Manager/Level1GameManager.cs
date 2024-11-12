using UnityEngine;

public class Level1GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _voiceStory;
    [SerializeField] private GameObject _useGunInstruction;
    [SerializeField] private GameObject _defeatZombieInstruction;
    [SerializeField] private GameObject _defeatZombies;

    void Start()
    {
        
    }

    public void PlayVoiceStoryAudio()
    {
        _voiceStory.SetActive(true);
    }

    public void UseGunInstruction()
    {
        _useGunInstruction.SetActive(true);
    }

    public void DefeatZombieInstruction()
    {
        _defeatZombieInstruction.SetActive(true);
    }

    public void DefeatZombies()
    {
        _defeatZombies.SetActive(true);
    }
}