using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESceneNames
{
    IntroScene,
    NetworkScene,
    ClientScene,
    ServerScene,
    ChangeSkinScene,
    ZombieDetailScene,
    MapLevelScene,
    Level1Scene,
    Level2Scene
}

public class Loader
{
    static public void LoadScene(ESceneNames scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }


    static public void LoadSceneAdditive(ESceneNames scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }

    // static public void UnloadAdditiveScene(ESceneNames scene)
    // {
    //     if (SceneManager.GetSceneByName(scene.ToString()).isLoaded)
    //     {
    //         SceneManager.UnloadSceneAsync(scene.ToString());
    //     }
    //     else
    //     {
    //         Debug.Log("[DEV, WARNING] Scene chưa được load hoặc đã bị xóa!");
    //     }
    // }

    static public bool IsSceneLoaded(ESceneNames scene)
    {
        return SceneManager.GetSceneByName(scene.ToString()).isLoaded;
    }

    static public void UnLoadAdditiveScene(ESceneNames scene, MonoBehaviour mono, Action onComplete)
    {
        mono.StartCoroutine(UnLoadAdditiveSceneCoroutine());
        IEnumerator UnLoadAdditiveSceneCoroutine()
        {
            if (!IsSceneLoaded(scene))
            {
                Debug.Log("[DEV, WARNING] Scene chưa được load hoặc đã bị xóa!");
                yield break;
            }

            var operation = SceneManager.UnloadSceneAsync(scene.ToString());
            while (!operation.isDone)
            {
                yield return new WaitForEndOfFrame();
            }

            onComplete?.Invoke();
        }
    }

}
