using UnityEngine;

public class OnWarZombieDestroyInstruction : MonoBehaviour
{
    void OnDestroy()
    {
        var level1SceneSpawnManager = GameObject.FindFirstObjectByType<Level1SceneSpawnManager>();
        level1SceneSpawnManager.SecondWave();
    }
}