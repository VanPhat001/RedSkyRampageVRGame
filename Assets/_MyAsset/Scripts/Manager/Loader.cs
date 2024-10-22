using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader
{
    public enum ESceneNames
    {
        IntroScene,
        NetworkScene,
        ClientScene,
        ServerScene,
        Level1Scene,
        Level2Scene
    }

    static public void LoadScene(ESceneNames scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }


    static public void LoadSceneAdditive(ESceneNames scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }
    
    
}
