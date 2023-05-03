using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public GameOverScreen GameOver;
    public float health = 0f; //andy made public 
    //[SerializeField] private float maxHealth = 100f; 
    public float maxHealth = 100f;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }
    //Call UpdateHealth in other programs to change it positivly or negativly for potions or attacks
    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        //Debug logger is a stand in for endgame/restart state
        else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("You Died");
            Destroy(gameObject); //Added for Game Over
            GameOver.Setup(); //Added for Game Over 
            // UIManager.instance.OameOverScreen();
        }

    }
}
