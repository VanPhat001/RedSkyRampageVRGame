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


}
