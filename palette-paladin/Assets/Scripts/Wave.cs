using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {

    [SerializeField] private SubWave[] waveComposition;
    private int wavei = 0;
    private int enemyj = 0;

    public int GetNextEnemy()
    {
        enemyj++;
        return waveComposition[wavei].GetEnemy;
    }

    public bool IsSubWaveFinished()
    {
        return enemyj == waveComposition[wavei].NumEnemies;
    }

    public bool IsWaveFinished()
    {
        return wavei == waveComposition.Length;
    }

    public void NextSubWave()
    {
        wavei++;
        enemyj = 0;
    }

    public float GetDelay()
    {
        return waveComposition[wavei].PostSpawnDelay;
    }

    public float GetSpawnRate()
    {
        return waveComposition[wavei].SpawnRate;
    }
	
}

[System.Serializable]
public class SubWave
{
    [SerializeField] private int[] indexRange;
    public int GetEnemy { get { return indexRange[(int)Random.Range(0, indexRange.Length)]; } }
    [SerializeField] private int numEnemies;
    public int NumEnemies { get { return numEnemies; } }
    [SerializeField] private float spawnRate;
    public float SpawnRate { get { return spawnRate; } }
    [SerializeField] private float postSpawnDelay;
    public float PostSpawnDelay { get { return postSpawnDelay; } }
}
