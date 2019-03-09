using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float spawnTime; 
    public float spawnDelay;
    public GameObject player;
    // public Palette.PalColor;

    void Start()
    {
    	InvokeRepeating("Spawn", spawnDelay, spawnTime);   
    }

    // Update is called once per frame
    void Spawn()
    {	
    	//TODO: find the game condition 
    	// if (false){
    	// 	return;
    	// }

		/*
		for spawning from a rectangle shape (the original plan)
		*/

    	Renderer rd = GetComponent<Renderer>();

    	float p1 = transform.position.x - rd.bounds.size.x/2;
    	float p2 = transform.position.x + rd.bounds.size.x/2;

    	/*
		spawning from a "u-shape"
    	*/
  //   	float theta = Random.Range(0,Mathf.PI);
  //   	float vectorX = Mathf.cos(theta)
  //   	float vectorY = Math.sin(theta)
  //   	float rectX = transform.position.x;
		// float playerX = player.transform.position.x;
  //   	float playerY = player.transform.position.y;




    	// float curr = Random.Range(p1,p2)
    	Vector2 spawnPoint = new Vector2(Random.Range(p1,p2),transform.position.y);

    	Instantiate(enemy, spawnPoint, Quaternion.identity);
    }


}
