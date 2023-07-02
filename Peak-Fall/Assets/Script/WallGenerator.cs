using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    [SerializeField] private WallPool wallPool;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall")) {
            wallPool.ReleaseWall(collision.gameObject);
            wallPool.SpawnWall();
        }
    }

}
