using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum SceneName
    {
        IntroScene,
        NetworkScene,
        ClientScene,
        ServerScene
    }

    public static void LoadSceneAdditive(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }

    public static void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }
}