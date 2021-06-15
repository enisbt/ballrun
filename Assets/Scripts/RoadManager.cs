using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> roads;
    [SerializeField] private float offset;
    [SerializeField] private GameObject roadPrefab;

    public void SpawnRoad()
    {
        GameObject lastRoad = roads[roads.Count - 1];
        GameObject newRoad = Instantiate(roadPrefab, lastRoad.transform.position + new Vector3(0, 0, -offset),
            Quaternion.identity);
        roads.Add(newRoad);
    }
}
