using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : Minion {

    [SerializeField] private float waitTime;
    private bool dontMove; // prevents runners from running after they've been killed

    public override void Spawn(EnemyManager e)
    {
        StartCoroutine(FreezeForTime());
    }

    // No death effect
    public override void Die()
    {
        StartCoroutine(this.DeathRoutine());
        this.dontMove = true;
    }

    private IEnumerator FreezeForTime()
    {
        stopWalking = true;
        yield return new WaitForSeconds(this.waitTime);
        stopWalking = false || dontMove; // do not start walking if the runner is dead
    }

}
