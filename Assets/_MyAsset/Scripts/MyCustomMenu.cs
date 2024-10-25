using UnityEditor;
using UnityEngine;

public class MyCustomMenu : MonoBehaviour
{
#if UNITY_EDITOR
    // Tạo mục menu mới "MyMenu" trên thanh menu
    [MenuItem("NetworkScene/Open")]
    private static void OpenNetworkScene()
    {
        // Code được thực thi khi nhấn nút "MyButton"
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/_MyAsset/Scenes/NetworkScene.unity");
    }
#endif
}
