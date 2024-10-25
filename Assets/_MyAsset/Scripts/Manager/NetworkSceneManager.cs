using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class NetworkSceneManager : MonoBehaviour
{
    [SerializeField] private BuildOptionSO _option;


    void Start()
    {
        StartCoroutine(ConnectNetworkCoroutine());
    }

    private IEnumerator ConnectNetworkCoroutine()
    {
        yield return new WaitUntil(() => NetworkManager.Singleton && Multiplayer.Singleton.IsReady);

        switch (_option.Option)
        {
            case EBuildOptions.BuildClientOnOculusAndDesktopDevice_ServerOnEditor:
                StartClientOnOculusAndDesktop_ServerOnEditor();
                break;
            case EBuildOptions.BuildClient:
                StartClient();
                break;
            case EBuildOptions.BuildServer:
                StartServer();
                break;
            default:
                throw new System.Exception();
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

    void ReConnectNetwork()
    {
        StartCoroutine(ReConnectNetworkCoroutine());
        IEnumerator ReConnectNetworkCoroutine()
        {
            for (int i = 3; i > 0; i--)
            {
                NetworkSceneUIManager.Singleton.Text.text = $"Something went wrong!!! Reconnect after {i}s...";
                yield return new WaitForSeconds(1);
            }

            NetworkSceneUIManager.Singleton.Text.text = "Something went wrong!!! Reconnecting...";
            yield return StartCoroutine(ConnectNetworkCoroutine());
        }
    }

    async void StartServer()
    {
        var success = await Multiplayer.Singleton.StartServer();
        if (!success)
        {
            Debug.Log("[DEV] is there anything wrong in the multiplayer script?");
            ReConnectNetwork();
            return;
        }

        if (NetworkManager.Singleton.StartServer())
        {
            Debug.Log("[DEV] start server!!!");
            Loader.LoadSceneAdditive(ESceneNames.ServerScene);
            NetworkSceneUIManager.Singleton.CloseLayout();
        }
        else
        {
            Debug.Log("[DEV] can not start server!!!");
            ReConnectNetwork();
        }
    }

    async void StartClient()
    {
        var success = await Multiplayer.Singleton.StartClient();
        if (!success)
        {
            Debug.Log("[DEV] is there anything wrong in the multiplayer script?");
            ReConnectNetwork();
            return;
        }

        if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("[DEV] start client!!!");
            Loader.LoadSceneAdditive(ESceneNames.ClientScene);
            NetworkSceneUIManager.Singleton.CloseLayout();
        }
        else
        {
            Debug.Log("[DEV] can not start client!!!");
            ReConnectNetwork();
        }
    }
}
