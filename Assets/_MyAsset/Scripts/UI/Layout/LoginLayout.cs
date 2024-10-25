using System;
using DemoObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginLayout : BaseLayout
{
    [SerializeField] private TMP_InputField _usernameInput;
    [SerializeField] private TMP_InputField _passwordInput;
    [SerializeField] private Button _loginButton;

    void Start()
    {
        _loginButton.onClick.AddListener(LoginUserAccount);

        this.RegisterListener(EEventIDs.ServerResponseAuthResult, ServerResponse_AuthPlayerByUsernameAndPassword);
    }

    private void ServerResponse_AuthPlayerByUsernameAndPassword(object authPlayerParamsObj)
    {
        var authPlayerParams = (AuthPlayerParams)authPlayerParamsObj;
        Debug.Log(authPlayerParams.IsFound + " " + authPlayerParams.DBPlayerId);

        if (authPlayerParams.IsFound)
        {
            ClientSceneUIManager.Singleton.LockLayout.CloseLayout();
            ClientSceneUIManager.Singleton.LogoLayout.OpenLayout();
        }
        else
        {
            // notify
            // Debug.Log("[DEV] Username or Password incorrect!!!");
            ClientSceneUIManager.Singleton.WarningLayout.OpenLayout(
                "Warning",
                "Username or Password incorrect!!!"
            );
        }
    }

    private bool Validate(string username, string password)
    {
        if (username == "")
        {
            ClientSceneUIManager.Singleton.WarningLayout.OpenLayout(
                "Warning",
                "Username must not be empty."
            );
            return false;
        }

        if (password == "")
        {
            ClientSceneUIManager.Singleton.WarningLayout.OpenLayout(
                "Warning",
                "Password must not be empty."
            );
            return false;
        }

        return true;
    }

    private void LoginUserAccount()
    {
        var username = GetUsername();
        var password = GetPassword();

        if (!Validate(username, password))
        {
            return;
        }

        NetworkCommunication.Singleton.AuthPlayerByUsernameAndPasswordServerRpc(username, password);
        // ---> waiting server response

        // ClientSceneUIManager.Singleton.LockLayout.CloseLayout();
    }


    private string GetUsername() => _usernameInput.text;
    private string GetPassword() => _passwordInput.text;
}