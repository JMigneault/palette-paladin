using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    // The speed of the enemy
    [SerializeField] protected float speed;

    // Tracks whether an enemy has been killed and should be cleared
    protected bool isDead = false;
    public bool IsDead { get { return isDead; } }

    // Called upon spawning of the enemy
    public abstract void Spawn(EnemyManager e);

    // Called to move the enemy from the Update method
    public abstract void Move();

    // Called when the enemy is killed
    public abstract void Die();

    // Called when a color is cast on the enemy
    public abstract void AttackedBy(Palette.PalColor attackColor);

}
