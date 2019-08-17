using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Eye eyeTemplate;
    [SerializeField] private Vector2[] eyePositions;
    private Eye[] eyes;
    private int nextEyeIndex = 0;

    private Vector3 targetPosition;
    private Enemy[] enemies;

    private void Start()
    {
        enemies = enemiesParent.GetComponentsInChildren<Enemy>();
        eyes = GetEyes(3);
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

    private Eye[] GetEyes(int numEyes)
    {
        Eye[] eyes = new Eye[numEyes];
        for (int i = 0; i < numEyes; i++)
        {
            eyes[i] = Instantiate(eyeTemplate);
            eyes[i].transform.parent = this.transform;
            Palette.PalColor randomColor = (Palette.PalColor)Random.Range(4, 7);
            eyes[i].SetColorPos(randomColor, eyePositions[i]);
        }
        return eyes;
    }

    public override void AttackedBy(Palette.PalColor attackColor)
    {
        if (eyes[nextEyeIndex].IsColor(attackColor))
        {
            eyes[nextEyeIndex].KillEye();
            nextEyeIndex++;
            if (nextEyeIndex == eyes.Length)
            {
                this.Die();
            }
        }
    }

    public override void Die()
    {
        isDead = true;
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
        return (targetPosition - transform.position).magnitude < this.speed * Time.deltaTime;
    }

    private void GenerateMinions()
    {
        Enemy toSpawn = enemies[canSpawnEnemies[(int) Random.Range(0, canSpawnEnemies.Length)]];
        spawner.Spawn(toSpawn, transform.position);
    }
}