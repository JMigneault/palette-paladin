﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private List<Enemy> enemies = new List<Enemy>();
    private AudioSource deathSound; // death sound effect for enemies 

    private void Start()
    {
        this.deathSound = GetComponents<AudioSource>()[0];
    }

    private void Update()
    {
        ClearEnemies();
    }

    // Casts a color on all enemies
    public void CastColor(Palette.PalColor color)
    {
        foreach (Enemy e in enemies)
        {
            e.AttackedBy(color);
        }
    }

    // Adds an enemy to the enemy list
    public void AddEnemy(Enemy e)
    {
        enemies.Add(e);
    }
	
	public bool hasEnemies()
	{
		return enemies.Count > 0;
	}

    // Updates the enemy list based on which enemies have been killed
    public void ClearEnemies()
    {
        List<Enemy> toRemove = new List<Enemy>();
        foreach (Enemy e in enemies)
        {
            if (e.IsDead)
            {
                deathSound.Play();
                Object.Destroy(e.gameObject);
                toRemove.Add(e);
            }
        }
        foreach (Enemy e in toRemove)
        {
            enemies.Remove(e);
        }
    }

}
