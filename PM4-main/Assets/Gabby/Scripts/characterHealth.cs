using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterHealth : MonoBehaviour
{

    public float health = 5;
    public GameObject healthFive;
    public GameObject healthFour;
    public GameObject healthThree;
    public GameObject healthThreeCope;
    public GameObject healthThreeCope2;
    public GameObject healthTwo;
    public GameObject healthOne;
    //public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        healthFive.SetActive(true);
        healthFour.SetActive(false);
        healthThree.SetActive(true);
        healthThreeCope.SetActive(false);
        healthThreeCope2.SetActive(false);
        healthTwo.SetActive(false);
        healthOne.SetActive(false);
        //loseScreen.SetActive(false);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<TopDownPlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 4) //this assumes health was previously 5
        {
           // healthThreeCope2.SetActive(true);
            healthFive.SetActive(false);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
           // healthTwo.SetActive(true);
        }
        if (health == 3) 
        {
            healthThreeCope2.SetActive(true);
            healthThreeCope.SetActive(true);
            healthFour.SetActive(false);
            healthThree.SetActive(true);
          //  healthTwo.SetActive(true);
        }
        if (health == 2) 
        {
            healthThreeCope2.SetActive(true);
            healthThreeCope.SetActive(true);
            healthThree.SetActive(false);
            healthTwo.SetActive(true);
        }
        else if (health == 1)
        {
            healthThreeCope2.SetActive(true);
            healthThreeCope.SetActive(true);
            healthThree.SetActive(false);
            healthTwo.SetActive(false);
            healthOne.SetActive(true);
        }
        else if (health <= 0)
        {
            healthThreeCope2.SetActive(false);
            healthThreeCope.SetActive(false);
            healthThree.SetActive(false);
            healthTwo.SetActive(false);
            healthOne.SetActive(false);
            //loseScreen.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TopDownPlayerMovement>().enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
