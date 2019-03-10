using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy
{

    // Minions have one static color
    [SerializeField] private Palette.PalColor color;
    [SerializeField] private Vector3 targetPos;

    // Called each frame
    private void Update()
    {
        Move();
    }

    // If the minion is hit by its color it is killed
    public override void AttackedBy(Palette.PalColor attackColor)
    {
        if (attackColor == this.color)
        {
            this.Die();
        }
    }

    // No death effect
    public override void Die()
    {
        this.isDead = true;
    }

    // Simply advance down the screen
    public override void Move()
    {
        Vector3 direction = (targetPos - this.transform.position).normalized;
        transform.position += this.speed * Time.deltaTime * direction;
    }

    // No spawn effect
    public override void Spawn() {  }
    
}
