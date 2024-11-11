using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WarZombie;

public class Level1SceneSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _warZombiePrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    void Start()
    {
    }

    public void FirstWave()
    {
        SpawnWarZombieAtRandomPoint();
    }

    public void SecondWave()
    {
        StartCoroutine(SpawnCoroutine());
        IEnumerator SpawnCoroutine()
        {
            SpawnWarZombieAtRandomPoint();
            yield return new WaitForSeconds(.6f);
            SpawnWarZombieAtRandomPoint();
            yield return new WaitForSeconds(.6f);
            SpawnWarZombieAtRandomPoint();
        }
    }

    FSMManager SpawnWarZombieAtRandomPoint()
    {
        var zombie = Instantiate(_warZombiePrefab).GetComponent<WarZombie.FSMManager>();
        var spawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count - 1)];

        zombie.transform.position = spawnPoint.position;
        zombie.transform.rotation = spawnPoint.rotation;
        zombie.Target = PlayerManager.Singleton.transform;

        return zombie;
    }
}