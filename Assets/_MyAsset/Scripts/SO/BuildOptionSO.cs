using UnityEngine;

[CreateAssetMenu(menuName = "RedSkyRampageVRGame/BuildOptionSO")]
public class BuildOptionSO : ScriptableObject
{
    [SerializeField] private BuildOption _option;
    public BuildOption Option => _option;
}


public enum BuildOption
{
    BuildClientOnOculusAndDesktopDevice_ServerOnEditor,
    BuildClient,
    BuildServer
}