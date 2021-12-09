using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZomb : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 4;
    private AIDestinationSetter targetz;
    public GameObject player;
    public GameObject Manager;
    private AudioSource death;
    void Start()
    {
        Manager = GameObject.Find("Game Controller");
        player = GameObject.Find("Player");
        targetz = GetComponent<AIDestinationSetter>();
        targetz.target = player.transform;
        death = Manager.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            death.pitch = (Random.Range(0.6f, .9f));
            death.Play();
            Destroy(this.gameObject);
        }

    
    }
        
//Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "MyGameObjectName")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "bullet")
        {
            health--;
            Destroy(collision.gameObject);
            Debug.Log("Enemy Hit!");
        }
    }
}
    