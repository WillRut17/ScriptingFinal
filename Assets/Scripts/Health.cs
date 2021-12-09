using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite heartFull;
    public Sprite heartEmpty;
    
    private bool invincible;
    private float invincTimer;
    public float totalInvincTime;

    private SpriteRenderer spr;
    public AudioSource gotHit;

    public GameObject gameManager;

    private void Start()
    {
        invincible = false;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = heartFull;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (invincible == true)
        {
            if(invincTimer >= totalInvincTime)
            {
                invincible = false;
                spr.color = new Color(1, 1, 1, 1);
            }
            else
            {
                invincTimer += 1 * Time.deltaTime;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie" && invincible == false)
        {
            gotHit.Play();
            health -= 1;
            if (health <= 0)
            {
                Score.score = gameManager.GetComponent<Timer>().time;
                SceneManager.LoadScene("GameOver");
            }
            invincible = true;
            spr.color = new Color(1, 1, 1, 0.4f);
            invincTimer = 0.0f;
        }
    }
}
