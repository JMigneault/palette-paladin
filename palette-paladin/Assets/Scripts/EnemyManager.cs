using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    // serializing temporary
    // todo integrate with enemy spawning
    [SerializeField] private List<Enemy> enemies;

    // Casts a color on all enemies
    public void CastColor(Palette.PalColor color)
    {
        foreach (Enemy e in enemies)
        {
            e.AttackedBy(color);
        }
        ClearEnemies();
    }

    // Updates the enemy list based on which enemies have been killed
    private void ClearEnemies()
    {
        List<Enemy> toRemove = new List<Enemy>();
        foreach (Enemy e in enemies)
        {
            if (e.IsDead)
            {
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
