using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class NetworkSceneManager : MonoBehaviour
{
    [SerializeField] private BuildOptionSO _option;
   

    void Start()
    {
        StartCoroutine(ConnectNetworkCoroutine());
        IEnumerator ConnectNetworkCoroutine()
        {
            yield return new WaitUntil(() => NetworkManager.Singleton && Multiplayer.Singleton.IsReady);

            switch (_option.Option)
            {
                case BuildOption.BuildClientOnOculusAndDesktopDevice_ServerOnEditor:
                    StartClientOnOculusAndDesktop_ServerOnEditor();
                    break;
                case BuildOption.BuildClient:
                    StartClient();
                    break;
                case BuildOption.BuildServer:
                    StartServer();
                    break;
                default:
                    throw new System.Exception();
            }
        }
    }

    void StartClientOnOculusAndDesktop_ServerOnEditor()
    {
        if (SystemInfo.operatingSystem.StartsWith("Android") && SystemInfo.deviceModel.StartsWith("Oculus"))
        {
            StartClient();
            return;
        }

        if (Application.isEditor)
        {
            StartServer();
        }
        else
        {
            StartClient();
        }
    }

    async void StartServer()
    {
        var success = await Multiplayer.Singleton.StartServer();
        if (!success)
        {
            Debug.Log("IS THERE ANYTHING WRONG IN THE MULTIPLAYER SCRIPT?");
            return;
        }

        if (NetworkManager.Singleton.StartServer())
        {
            // Debug.Log("START SERVER!!!");
            Loader.LoadSceneAdditive(Loader.SceneName.ServerScene);
        }
        else
        {
            Debug.Log("CAN NOT START SERVER!!!");
        }
    }

    async void StartClient()
    {
        var success = await Multiplayer.Singleton.StartClient();
        if (!success)
        {
            Debug.Log("IS THERE ANYTHING WRONG IN THE MULTIPLAYER SCRIPT?");
            return;
        }

        if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("START CLIENT!!!");
            Loader.LoadSceneAdditive(Loader.SceneName.ClientScene);
        }
        else
        {
            Debug.Log("CAN NOT START CLIENT!!!");
        }
    }
}
