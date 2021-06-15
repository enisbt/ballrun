using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacleSpawnPoints;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private bool firstFragment = false;

    private RoadManager roadManager;

    private void Start()
    {
        roadManager = FindObjectOfType<RoadManager>();
        SpawnObstacles();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            roadManager.SpawnRoad();
        }
    }

    private void SpawnObstacles()
    {
        if (!firstFragment)
        {
            for (int i = 0; i < obstacleSpawnPoints.Length; i++)
            {
                int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
                Instantiate(obstaclePrefabs[randomObstacleIndex], obstacleSpawnPoints[i].transform.position,
                    Quaternion.identity);
            }
        }
    }
}
