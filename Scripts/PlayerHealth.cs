using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //creates serialized fields to access info from unity
    [SerializeField]
    //create healthbar slider
    Slider healthBar;
    [SerializeField]
    //creates healthbar Text
    TextMeshProUGUI healthText;
    //set player maxhealth
    float maxHealth = 100;
    //set player health;
    float currHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = maxHealth;
        currHealth = healthBar.value;
    }

    //Player Collision Damage Dectector (checks player collision)
    private void OnTriggerStay2D(Collider2D col)
    {
        //if colliding with enemy
        if (col.gameObject.tag == "Enemy")
        {
            healthBar.value -= 2f;
            currHealth = healthBar.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currHealth.ToString() + " %";
    }
}
