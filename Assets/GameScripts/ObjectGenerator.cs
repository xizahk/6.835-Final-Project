using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] Collectibles;
    public GameObject[] Obstacles;

    // Use this for initialization
    void Start()
    {
        //first, let's decide whether we'll place an obstacle
        bool placeObstacle = Random.Range(0, 2) == 0; //50% chances
        int obstacleIndex = -1;
        if (placeObstacle)
        {
            //select a random spawn point, apart from the first one
            //since we do not want an obstacle there
            obstacleIndex = Random.Range(1, SpawnPoints.Length);
            if (obstacleIndex >= SpawnPoints.Length)
            {
                Debug.Log("Index is too big!\nLength: " + SpawnPoints.Length.ToString() + "index" + obstacleIndex.ToString());
            }
            CreateObject(SpawnPoints[obstacleIndex].position, Obstacles[Random.Range(0, Obstacles.Length)]);
        }

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            //don't instantiate if there's an obstacle
            if (i == obstacleIndex) continue;
            if (Random.Range(0, 3) == 0) //33% chances to create candy
            {
                CreateObject(SpawnPoints[i].position, Collectibles[Random.Range(0, Collectibles.Length)]);
            }
        }
    }

    void CreateObject(Vector3 position, GameObject prefab)
    {
        if (prefab.name.Contains("Sphere")) {
            position += new Vector3(0, Random.Range(Constants.COLLECTIBLE_MIN_Y, Constants.COLLECTIBLE_MAX_Y), 0);
        } 
        else if (prefab.name.Contains("GreenPipe"))
        {
            position += new Vector3(0, Random.Range(Constants.COLLECTIBLE_MIN_Y, Constants.COLLECTIBLE_MAX_Y), 0);
        }
        Instantiate(prefab, position, Quaternion.identity);
    }
}