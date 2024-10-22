using UnityEngine;

[CreateAssetMenu(menuName = "RedSkyRampageVRGame/BuildOptionSO")]
public class BuildOptionSO : ScriptableObject
{
    [TextArea(8, 20)] [SerializeField] private string _description;

    [Space]
    [Space]
    [SerializeField] private EBuildOptions _option;
    public EBuildOptions Option => _option;


    private void OnValidate()
    {
        switch (_option)
        {
            case EBuildOptions.BuildClientOnOculusAndDesktopDevice_ServerOnEditor:
                _description = "Build Client trên:\n  - Oculus.\n  - Thiết bị Desktop.\n\nBuild Server trên Editor.";
                break;
            case EBuildOptions.BuildClient:
                _description = "Chỉ build Client.";
                break;
            case EBuildOptions.BuildServer:
                _description = "Chỉ build Server.";
                break;
            default:
                _description = "Không có mô tả.";
                break;
        }
    }
}

public enum EBuildOptions
{
    BuildClientOnOculusAndDesktopDevice_ServerOnEditor,
    BuildClient,
    BuildServer
}
