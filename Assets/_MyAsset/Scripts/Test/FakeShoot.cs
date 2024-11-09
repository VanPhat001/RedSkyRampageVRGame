using UnityEngine;

public class FakeShoot : MonoBehaviour
{
    public Pistol Pistol;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Pistol.Fire();
        }
        if (Input.GetKey(KeyCode.E))
        {
            Pistol.Reload();
        }
    }
}