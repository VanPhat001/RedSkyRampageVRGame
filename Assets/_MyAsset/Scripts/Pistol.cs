using System.Collections;
using UnityEngine;

public class Pistol : BaseGun
{
    [Tooltip("Sức chứa của băng đạn")]
    [SerializeField] private int _ammoCapacity = 17;

    [Tooltip("Tổng số lượng viên đạn hiện có trong băng đạn")]
    [SerializeField] private int _ammoAvaiable = 17;

    [Tooltip("Tổng số đạn hiện người chơi đang mang theo hoặc súng đang có")]
    [SerializeField] private int _totalCapacity = 170;

    [Tooltip("Khoảng thời gian chờ giữa 2 lần bắn")]
    [SerializeField] private float _fireRate = .2f; // second

    [Tooltip("Khoảng thời gian chờ reload đạn")]
    [SerializeField] private float _reloadRate = 1.5f; // second

    [SerializeField] private GameObject _bulletPrefab;

    private float _fireTimer = 0;
    private bool _isReloading = false;

    protected override void Update()
    {
        base.Update();

        _fireTimer -= Time.deltaTime;
    }

    public override bool CanShoot()
    {
        return !_isReloading && _ammoAvaiable > 0 && _fireTimer <= 0;
    }

    public override bool Fire()
    {
        if (!CanShoot())
        {
            return false;
        }

        _ammoAvaiable--;
        _fireTimer = _fireRate;
        // spawn bullet

        return true;
    }

    public override bool Reload()
    {
        // if (_totalCapacity <= 0)
        // {
        //     return false;
        // }

        // if (_ammoAvaiable == _ammoCapacity)
        // {
        //     return false;
        // }

        if (_isReloading)
        {
            return false;
        }

        var ammoAdded = Mathf.Min(_totalCapacity, _ammoCapacity - _ammoAvaiable);
        if (ammoAdded == 0)
        {
            return false;
        }

        StartCoroutine(ReloadCoroutine(ammoAdded));

        return true;
    }

    public void CancelReload()
    {
        _isReloading = false;
        StopAllCoroutines();
    }

    IEnumerator ReloadCoroutine(int ammoAdded)
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadRate);

        _ammoAvaiable += ammoAdded;
        _totalCapacity -= ammoAdded;

        _fireTimer = 0;
        _isReloading = false;
    }
}