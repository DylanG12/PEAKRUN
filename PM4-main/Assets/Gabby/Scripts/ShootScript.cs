using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public int speed = 5;
    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public IEnumerator shoot(float xLocation, float yLocation) //shoot method DON'T USE THIS METHOD
    {
        
        yield return new WaitForSeconds(0.001f);
        int rise = (int) (yLocation - transform.position.y);
        int run = (int) (xLocation - transform.position.x);
        bool risePos = true;
        bool runPos = true;
        if (rise < 0)
        {
            risePos = false;
        }
        if (run < 0)
        {
            runPos = false;
        }
        rise = System.Math.Abs(rise);
        run = System.Math.Abs(run);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().isTrigger = true;
        for (int r = distance; r > 0; r--)
        {

            for (int i = rise; i > 0; i--)
            {
                if (!risePos)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }
                else if (risePos)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            for (int k = run; k > 0; k--)
            {
                if (!runPos)
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else if (runPos)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
            }
            yield return new WaitForSeconds(0.002f);

        }
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().isTrigger = false;
            GetComponent<TrailRenderer>().enabled = false;

    }

    public void shootWithCoroutine(float xLocation, float yLocation, float xStart, float yStart) //shoot method that allows waiting USE THIS METHOD
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
        GetComponent<Transform>().position = new Vector3(xStart, yStart, 0);
        StartCoroutine(shoot(xLocation, yLocation));
    }

    public void OnTriggerEnter2D(Collider2D other) //takes health from player if the player has a characterHealth script and a Player tag
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<characterHealth>().health -= 1;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().isTrigger = false;
            Shake.start = true;
        }
        if (other.gameObject.CompareTag("Explosive"))
        {
            other.GetComponent<Animator>().SetInteger("aniRun", 2);
            other.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (other.gameObject.CompareTag("Blocker"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
