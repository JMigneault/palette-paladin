using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Enemy
{

    [SerializeField] private GameObject enemiesParent;
    [SerializeField] private float spawnBoundsXmin;
    [SerializeField] private float spawnBoundsXmax;
    [SerializeField] private float spawnBoundsYmin;
    [SerializeField] private float spawnBoundsYmax;
    [SerializeField] private Spawner spawner;
    [SerializeField] private float minWalkDistance;
    [SerializeField] private int[] canSpawnEnemies;

    private Vector3 targetPosition;
    private Enemy[] enemies;

    private void Start()
    {
        enemies = enemiesParent.GetComponentsInChildren<Enemy>();
    }

    private void Update()
    {
        if (ReachedTarget())
        {
            this.targetPosition = ChooseTarget();
            GenerateMinions();
        }
        Move();
    }

    public override void AttackedBy(Palette.PalColor attackColor)
    {
        // todo
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        Vector3 direction = (targetPosition - this.transform.position).normalized;
        transform.position += this.speed * Time.deltaTime * direction;
    }

    public override void Spawn(EnemyManager e)
    {
        this.targetPosition = ChooseTarget();
        this.spawner = e.GetComponent<Spawner>();
    }

    private Vector3 ChooseTarget()
    {
        Vector3 candidatePosition = new Vector3(Random.Range(spawnBoundsXmin, spawnBoundsXmax), Random.Range(spawnBoundsYmin, spawnBoundsYmax), 0);
        if ((this.transform.position - candidatePosition).magnitude < this.minWalkDistance)
        {
            return ChooseTarget();
        } else
        {
            return candidatePosition;
        }
    }

    private bool ReachedTarget()
    {
        return (targetPosition - transform.position).magnitude < this.speed;
    }

    private void GenerateMinions()
    {
        Enemy toSpawn = enemies[canSpawnEnemies[(int) Random.Range(0, canSpawnEnemies.Length)]];
        spawner.Spawn(toSpawn, transform.position);
    }
}
