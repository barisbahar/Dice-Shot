using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coord
{
    public float x;
    public float z;
    public Coord(float _x, float _z)
    {
        this.x = _x;
        this.z = _z;
    }
}

public class Spawnpoint
{
    public Coord location;
    public Spawnpoint(float _x, float _z)
    {
        this.location = new Coord(_x, _z);
    }
    public float getX()
    {
        return this.location.x;
    }
    public float getZ()
    {
        return this.location.z;
    }
}

public class Manager : MonoBehaviour
{
    public GameObject assassinModel;
    Dictionary<int, Spawnpoint> AllySpawnPoints = new Dictionary<int, Spawnpoint>();
    Dictionary<int, Spawnpoint> EnemySpawnPoints = new Dictionary<int, Spawnpoint>();
    void InitAllies()
    {
        AllySpawnPoints.Add(1, new Spawnpoint(2.97f, -0.48f));
        AllySpawnPoints.Add(2, new Spawnpoint(2.97f, 1.92f));
        AllySpawnPoints.Add(3, new Spawnpoint(2.97f, -3.01f));
        AllySpawnPoints.Add(4, new Spawnpoint(2.97f, 4.4f));
        AllySpawnPoints.Add(5, new Spawnpoint(2.97f, -5.37f));
        AllySpawnPoints.Add(6, new Spawnpoint(5.28f, 0.89f));
        AllySpawnPoints.Add(7, new Spawnpoint(5.28f, -1.8f));
        AllySpawnPoints.Add(8, new Spawnpoint(6.85f, -0.48f));
    }
    void InitEnemies()
    {
        EnemySpawnPoints.Add(1, new Spawnpoint(-4.17f, -0.48f));
        EnemySpawnPoints.Add(2, new Spawnpoint(-4.17f, 1.92f));
        EnemySpawnPoints.Add(3, new Spawnpoint(-4.17f, -3.01f));
        EnemySpawnPoints.Add(4, new Spawnpoint(-4.17f, 4.4f));
        EnemySpawnPoints.Add(5, new Spawnpoint(-4.17f, -5.37f));
        EnemySpawnPoints.Add(6, new Spawnpoint(-6.55f, 0.89f));
        EnemySpawnPoints.Add(7, new Spawnpoint(-6.55f, -1.8f));
        EnemySpawnPoints.Add(8, new Spawnpoint(-9.15f, -0.48f));
    }
    void InitializeAssassins()
    {
        // Spawn Allies
        for (int i = 1; i <= 5; i++)
        {
            Spawnpoint tempSP_A = AllySpawnPoints[i];
            Instantiate(assassinModel, new Vector3(tempSP_A.getX(), 0.8028336f, tempSP_A.getZ()), Quaternion.Euler(0f, 270f, 0f)).tag = "BluePlayer";
        }
        // Spawn Enemies
        for (int i = 1; i <= 5; i++)
        {
            Spawnpoint tempSP_E = EnemySpawnPoints[i];
            Instantiate(assassinModel, new Vector3(tempSP_E.getX(), 0.8028336f, tempSP_E.getZ()), Quaternion.Euler(0f, 90f, 0f)).tag = "RedPlayer";
        }
    }
    void Start()
    {
        InitAllies();
        InitEnemies();
        InitializeAssassins();
    }
    void Update()
    {

    }
}
