using UnityEngine;
using UnityEngine.Pool;

public class WallPool : MonoBehaviour {
    [SerializeField] private GameObject wallPrefab;

    [SerializeField] private float currSpawnPos = -10;

    [SerializeField] private bool collectionChecks = true;

    [SerializeField] private int maxPoolSize = 15;

    public IObjectPool<GameObject> m_pool { get; set; }

    private void Start() {
        m_pool = new ObjectPool<GameObject>(createWall, takeFromPool, returnToPool, destroyPoolObject, collectionChecks, 10, maxPoolSize);
    }

    public void SpawnWall() {
        m_pool.Get();
    }

    public void ReleaseWall(GameObject wall) {
        m_pool.Release(wall);
    }

    private GameObject createWall() {
        GameObject wall = Instantiate(wallPrefab, transform);
        wall.SetActive(false);
        return wall;
    }

    private void takeFromPool(GameObject wall) {
        wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + currSpawnPos, 0);
        wall.gameObject.SetActive(true);
    }

    private void returnToPool(GameObject wall) {
        wall.gameObject.SetActive(false);
    }

    private void destroyPoolObject(GameObject wall) {
        Destroy(wall);
    }

}


 
