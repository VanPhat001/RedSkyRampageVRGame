using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Singleton { get; private set; }


    [SerializeField] private PlayerShoot _playerShoot;
    public PlayerShoot PlayerShoot => _playerShoot;

    [SerializeField] private PlayerWeapon _playerWeapon;
    public PlayerWeapon PlayerWeapon => _playerWeapon;

    [SerializeField] private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth;


    [ContextMenu("Auto Fill")]
    void AutoFill()
    {
        _playerShoot = this.GetComponentInChildren<PlayerShoot>();
        _playerWeapon = this.GetComponentInChildren<PlayerWeapon>();
        _playerHealth = this.GetComponentInChildren<PlayerHealth>();
    }

    void Awake()
    {
        Singleton = this;
    }

    void OnDestroy()
    {
        Singleton = null;
    }
}