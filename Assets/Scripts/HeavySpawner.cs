using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeBetween = 15;
    public GameObject Zombie;
    private int totalspawned = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeBetween -= Time.deltaTime;
        //Debug.Log(timeBetween);
        if (timeBetween <= 0)
        {
            Instantiate(Zombie);
            Zombie.transform.position = this.transform.position;
            Zombie.transform.position = new Vector3(Zombie.transform.position.x, Zombie.transform.position.y, 0);
            timeBetween = Random.Range(5, 20);
            Debug.Log("Zombie Spawn");
            totalspawned++;
        }
        if (timeBetween <= 0 && totalspawned < 15 && totalspawned > 5)
        {
            Instantiate(Zombie);
            Zombie.transform.position = this.transform.position;
            Zombie.transform.position = new Vector3(Zombie.transform.position.x, Zombie.transform.position.y, 0);
            timeBetween = Random.Range(1, 10);
            Debug.Log("Zombie Spawn");
            totalspawned++;
        }
        if (timeBetween <= 0 && totalspawned > 15)
        {
            Instantiate(Zombie);
            Zombie.transform.position = this.transform.position;
            Zombie.transform.position = new Vector3(Zombie.transform.position.x, Zombie.transform.position.y, 0);
            timeBetween = Random.Range(1, 5);
            Debug.Log("Zombie Spawn");
            totalspawned++;
        }
    }
}