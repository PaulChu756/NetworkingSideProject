using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numOfEnemies;

    /// <summary>
    /// Spawns enemyes, first gets the positions to spawn in X or Z axis, then use do random rotation of 0 to 180
    /// Then spawn enemies.
    /// </summary>
    public override void OnStartServer()
    {
        for (int i = 0; i < numOfEnemies; ++i)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));

            Quaternion spawnRot = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);

            GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPos, spawnRot);

            NetworkServer.Spawn(enemy);
        }
    }
}
