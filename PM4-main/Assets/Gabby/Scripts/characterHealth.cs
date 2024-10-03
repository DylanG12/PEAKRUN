using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterHealth : MonoBehaviour
{
    public static characterHealth charHealth;

    private void Awake() => charHealth = this;

    public int health = 5;
    public int maxHealth = 5;
    public GameObject healthTen;
    public GameObject nullTen;
    public GameObject healthNine;
    public GameObject nullNine;
    public GameObject healthEight;
    public GameObject nullEight;
    public GameObject healthSeven;
    public GameObject nullSeven;
    public GameObject healthSix;
    public GameObject nullSix;
    public GameObject healthFive;
    public GameObject nullFive;
    public GameObject healthFour;
    public GameObject nullFour;
    public GameObject healthThree;
    public GameObject nullThree;
    public GameObject healthTwo;
    public GameObject nullTwo;
    public GameObject healthOne;
    public GameObject nullOne;
    //public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        healthTen.SetActive(false);
        nullTen.SetActive(false);
        healthNine.SetActive(false);
        nullNine.SetActive(false);
        healthEight.SetActive(false);
        nullEight.SetActive(false);
        healthSeven.SetActive(false);
        nullSeven.SetActive(false);
        healthSix.SetActive(false);
        nullSix.SetActive(false);
        healthFive.SetActive(false);
        nullFive.SetActive(false);
        healthFour.SetActive(false);
        nullFour.SetActive(false);
        healthThree.SetActive(false);
        nullThree.SetActive(false);
        healthTwo.SetActive(false);
        nullTwo.SetActive(false);
        healthOne.SetActive(false);
        nullOne.SetActive(false);
        //loseScreen.SetActive(false);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<TopDownPlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 10)
        {
            healthTen.SetActive(true);
            healthNine.SetActive(true);
            healthEight.SetActive(true);
            healthSeven.SetActive(true);
            healthSix.SetActive(true);
            healthFive.SetActive(true);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
            healthTwo.SetActive(true);
            healthOne.SetActive(true);
            
        }

        if (health == 9 && maxHealth == 10)
        {
            healthTen.SetActive(false);
            nullTen.SetActive(true);
        }

        if (health == 9)
        {
            healthNine.SetActive(true);
            healthEight.SetActive(true);
            healthSeven.SetActive(true);
            healthSix.SetActive(true);
            healthFive.SetActive(true);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
            healthTwo.SetActive(true);
            healthOne.SetActive(true);
        }

        if (health == 8 && maxHealth >= 9)
        {
            healthNine.SetActive(false);
            nullNine.SetActive(true);
        }

        if (health == 8)
        {
            healthEight.SetActive(true);
            healthSeven.SetActive(true);
            healthSix.SetActive(true);
            healthFive.SetActive(true);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
            healthTwo.SetActive(true);
            healthOne.SetActive(true);
        }

        if (health == 7 && maxHealth >= 8)
        {
            healthEight.SetActive(false);
            nullEight.SetActive(true);
        }

        if (health == 7)
        {
            healthSeven.SetActive(true);
            healthSix.SetActive(true);
            healthFive.SetActive(true);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
            healthTwo.SetActive(true);
            healthOne.SetActive(true);

        }

        if (health == 6 && maxHealth >= 7)
        {
            healthSeven.SetActive(false);
            nullSeven.SetActive(true);
        }

        if (health == 6)
        {
            healthSix.SetActive(true);
            healthFive.SetActive(true);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
            healthTwo.SetActive(true);
            healthOne.SetActive(true);
        }

        if (health == 5 && maxHealth >= 6)
        {
            healthSix.SetActive(false);
            nullSix.SetActive(true);
        }

        if (health == 5)
        {
            healthFive.SetActive(true);
            healthFour.SetActive(true);
            healthThree.SetActive(true);
            healthTwo.SetActive(true);  
            healthOne.SetActive(true);  
        }

        if (health == 4) //this assumes health was previously 5
        {
            healthFive.SetActive(false);
            nullFive.SetActive(true);
        }
        if (health == 3) 
        {
            healthFour.SetActive(false);
            nullFour.SetActive(true);
          //  healthTwo.SetActive(true);
        }
        if (health == 2) 
        {
            healthThree.SetActive(false);
            nullThree.SetActive(true);
        }
        else if (health == 1)
        {
            healthTwo.SetActive(false);
            nullTwo.SetActive(true);
        }
        else if (health <= 0)
        {
            //loseScreen.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TopDownPlayerMovement>().enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
