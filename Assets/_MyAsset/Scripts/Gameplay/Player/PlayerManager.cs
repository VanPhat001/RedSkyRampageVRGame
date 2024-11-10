using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
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

    public void GetHit(float damage)
    {
        var newHP = Mathf.Clamp(_playerHealth.GetHP() - damage, 0, 100);
        _playerHealth.SetHP(newHP);
        
        Debug.Log("[DEV] Player HP " + _playerHealth.GetHP());
        if (_playerHealth.GetHP() <= 0)
        {
            Debug.Log("[DEV, INFO] Player Death");
        }
    }
}