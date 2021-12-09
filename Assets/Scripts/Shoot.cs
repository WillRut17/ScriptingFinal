using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;

    public int ammo;
    public int ammoLeft;

    public Image[] shells;
    public Sprite shellFull;
    public Sprite shellEmpty;

    private bool canShoot;
    private float reloadTimer;
    public float totalReloadTime;

    Vector2 lookDirection;
    float lookAngle;

    public Slider slider;
    public GameObject reloadObject;

    public AudioSource gunSound;
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        reloadObject.SetActive(false);
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot == true)
            {
                ammoLeft -= 1;
                gunSound.pitch = Random.Range(.7f, 1.3f);
                gunSound.Play();
                ani.Play("playershoot");
                if (ammoLeft <= 0)
                {
                    reloadTimer = 0.0f;
                    reloadObject.SetActive(true);
                    SetReload(reloadTimer);
                    canShoot = false;
                }
                for (int i = 0; i < 10; i++)
                {
                    Bullet();
                    //Debug.Log(i);
                }
            }
        }

        if (ammoLeft > ammo)
        {
            ammoLeft = ammo;
        }

        for (int i = 0; i < shells.Length; i++)
        {
            if (i < ammoLeft)
            {
                shells[i].sprite = shellFull;
            }
            else
            {
                shells[i].sprite = shellEmpty;
            }
            if (i < ammo)
            {
                shells[i].enabled = true;
            }
            else
            {
                shells[i].enabled = false;
            }
        }

        if (canShoot == false)
        {
            if (reloadTimer >= totalReloadTime)
            {
                SetReload(reloadTimer + 1);
                reloadObject.SetActive(false);
                canShoot = true;
                ammoLeft = ammo;
            }
            else
            {
                reloadTimer += 1 * Time.deltaTime;
                SetReload(reloadTimer);
                ani.Play("playerreload");
            }
        }
        ani.Play("shooting", -1, 0f);
    }
    private void Bullet()
    {
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = firePoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        float ranRang = Mathf.Deg2Rad * Random.Range(-15.0f, 15.0f);

        //Debug.Log(firePoint.right);

        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(firePoint.right.x + ranRang, firePoint.right.y + ranRang, firePoint.right.z) * bulletSpeed;
    }
    private void SetReload(float reload)
    {
        slider.value = reload;
    }
}
