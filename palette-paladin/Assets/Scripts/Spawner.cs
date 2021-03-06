﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyParent;
    private Enemy[] enemies;

    private EnemyManager enemyManager;

    [SerializeField] private WaveTracker waveTracker;

    [SerializeField] private Wave[] waves;
    private int currentWave = 0;
    private bool startNextWave = false;

    // Parameters defining the sliders path curveRadius(X/Y) values in range [0.0f, 1.0f] as proportion of screen
    [SerializeField] private float curveRadiusX;
    [SerializeField] private float curveRadiusY;
    [SerializeField] private float minAngle; // Angles in radians/pi => 2 is 360 degrees, 1 is a semicircle, 5/6 is 5/12 of a circle
    [SerializeField] private float maxAngle;

    private float curveOffsetX; // Pixel offsets for starting position
    private float curveOffsetY;

    private AudioSource spawnSound; // Sound that plays when enemies are spawned

    // Changes the position proportion ([0.0f, 1.0f]) to a pixel position on the screen
    public Vector2 PosToCoords(float pos)
    {
        float t = minAngle * Mathf.PI + (maxAngle - minAngle) * Mathf.PI * pos;
        float x = curveRadiusX * Mathf.Cos(t) + curveOffsetX;
        float y = curveRadiusY * Mathf.Sin(t) + curveOffsetY;
        return new Vector2(x, y);
    }

    void Start()
    {
        spawnSound = GetComponents<AudioSource>()[1];
        curveOffsetX = this.transform.position.x;
        curveOffsetY = this.transform.position.y;
        enemyManager = this.GetComponent<EnemyManager>();
        enemies = enemyParent.GetComponentsInChildren<Enemy>();
        StartWave(waves[0]);
        if (currentWave != waves.Length - 1)
        {
            currentWave++;
        }
    }

    private void Update()
    {
        if (startNextWave)
        {
            waveTracker.WaveCompleted();
            StartWave(waves[currentWave]);
            if (currentWave != waves.Length - 1)
            {
                currentWave++;
                waveTracker.NextWave();
            }
        }
    }

    private void StartWave(Wave w)
    {
        startNextWave = false;
        w.ResetWave();
        waveTracker.SliderSpeed = w.SliderSpeed;
        StartCoroutine(SpawnWave(w));
    }

    private IEnumerator SpawnWave(Wave w)
    {
        while (!w.IsWaveFinished())
        {
            while (!w.IsSubWaveFinished())
            {
                Enemy nextEnemy = enemies[w.GetNextEnemy()];
                Spawn(nextEnemy);
                yield return new WaitForSeconds(w.GetSpawnRate());
            }
			while (enemyManager.hasEnemies())
			{
				yield return new WaitForSeconds(1);
			}
            yield return new WaitForSeconds(w.GetDelay());
            w.NextSubWave();
        }
        startNextWave = true;
    }

    public void Spawn(Enemy e, Vector3 spawnPoint)
    {
        spawnSound.Play();
        Enemy spawned = Instantiate(e.gameObject, spawnPoint, Quaternion.identity).GetComponent<Enemy>();
        enemyManager.AddEnemy(spawned);
        spawned.Spawn(enemyManager);
    }

    public void Spawn(Enemy e)
    {
        Vector2 spawnPoint = PosToCoords(Random.value);
        Spawn(e, spawnPoint);
    }

}
