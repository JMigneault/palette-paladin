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
    [SerializeField] private SpawnInfo[] spawnInfo;
    public int GetEnemy {
		get {
			float total = 0f;
			for (int i = 0; i < spawnInfo.Length; i++)
			{
				total += spawnInfo[i].Probability;
			}
			float rand = Random.Range(0f, total);
			while (rand == total)
			{
				rand = Random.Range(0f, total);
			}
			float cumulative = 0f;
			for (int i = 0; i < spawnInfo.Length; i++)
			{
				cumulative += spawnInfo[i].Probability;
				if (rand < cumulative)
				{
					return spawnInfo[i].EnemyIndex;
				}
			}
		}
	}
    [SerializeField] private int numEnemies;
    public int NumEnemies { get { return numEnemies; } }
    [SerializeField] private float spawnRate;
    public float SpawnRate { get { return spawnRate; } }
    [SerializeField] private float postSpawnDelay;
    public float PostSpawnDelay { get { return postSpawnDelay; } }
}

[System.Serializable]
public class SpawnInfo
{
	[SerializeField] int enemyIndex;
	public int EnemyIndex { get { return enemyIndex; } }
	[SerializeField] float probability;
	public int Probability { get { return probability; } }
}
