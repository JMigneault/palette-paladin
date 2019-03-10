using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject minionParent;
    private Minion[] minions;
    public float spawnTime; 
    public float spawnDelay;

    private EnemyManager enemyManager;

    // Parameters defining the sliders path curveRadius(X/Y) values in range [0.0f, 1.0f] as proportion of screen
    [SerializeField] private float curveRadiusX;
    [SerializeField] private float curveRadiusY;
    [SerializeField] private float minAngle; // Angles in radians/pi => 2 is 360 degrees, 1 is a semicircle, 5/6 is 5/12 of a circle
    [SerializeField] private float maxAngle;

    private float curveOffsetX; // Pixel offsets for starting position
    private float curveOffsetY;


    void Start()
    {
        curveOffsetX = this.transform.position.x;
        curveOffsetY = this.transform.position.y;
        enemyManager = this.GetComponent<EnemyManager>();
        minions = minionParent.GetComponentsInChildren<Minion>();
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Changes the position proportion ([0.0f, 1.0f]) to a pixel position on the screen
    public Vector2 PosToCoords(float pos)
    {
        float t = minAngle * Mathf.PI + (maxAngle - minAngle) * Mathf.PI * pos;
        float x = curveRadiusX * Mathf.Cos(t) + curveOffsetX;
        float y = curveRadiusY * Mathf.Sin(t) + curveOffsetY;
        return new Vector2(x, y);
    }

    // Update is called once per frame
    private void Spawn()
    {
        float spawnPos = Random.value;
        Vector2 spawnPoint = PosToCoords(spawnPos);
        Minion toSpawn = minions[(int)Random.Range(0, minions.Length)];
    	Minion spawned = Instantiate(toSpawn, spawnPoint, Quaternion.identity);
        enemyManager.AddEnemy(spawned);
        spawned.Spawn();
    }


}
