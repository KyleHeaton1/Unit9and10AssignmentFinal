using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public ARCursor playerManager;
    public GameObject playerManagerObject;

    public ScoreManager scoreManager;
    public GameObject scoreManagerObject;
    
    public GameObject bloodObject;
    public ParticleSystem blood;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;

        playerManagerObject = GameObject.Find("AR Camera");
        playerManager = playerManagerObject.GetComponent<ARCursor>();

        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        blood = bloodObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("ammo");  
            playerManager.ammo += 20;
            scoreManager.score += 1;
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        blood.Play();
        FindObjectOfType<AudioManager>().Play("demonDeath");
    }
}
