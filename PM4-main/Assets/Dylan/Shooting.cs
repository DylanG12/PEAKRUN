using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting shoot;

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private double timer;
    public float timeBetweenFiring;
    public int maxAmmo = 50;
    public int totalMaxAmmo = 50;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shoot = this;
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = -0.35;
                maxAmmo--;
                if (maxAmmo <= 0)
                {
                    canFire = false;
                    maxAmmo = 0;
                }
            }
        }


        if(Input.GetMouseButton(0) && canFire)   
        {
            canFire = false;
            var newBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Destroy(newBullet, 2.0f);
        }
    }
}
