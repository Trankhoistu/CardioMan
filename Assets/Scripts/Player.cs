using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
	public Timer timer;

    private int selectedOption = 0;

	public int maxHealth = 100;

	// added static
	public static int currentHealth;
	public HealthBar healthBar;

	public float magnetRange = 5f;
	public float magnetForce = 10f;
	public string coinTag = "MyCoin";

	public int dumbellCollected = 0; // Tracks the number of special items collected
	public int itemsNeededToDefeatBoss = 3; // Number of items needed to defeat the boss	
	public GameObject flagPrefab;

    // Start is called before the first frame update
    void Start()
    {
		if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
		
        UpdateCharacter(selectedOption);
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
		// Changed KeyCode.Space to KeyCode.T for testing
		if (Input.GetKeyDown(KeyCode.T))
		{
			TakeDamage(20);
			
		}

		if (currentHealth <= 0)
		{
			SceneManager.LoadScene("DeathScreen");
		}
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	public void HealthBox(int health)
	{
		currentHealth += health;

		healthBar.SetHealth(currentHealth);
	}
	private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "MySpike")
        {
			// Minus health
			TakeDamage(15);
        }

		if (obj.tag == "MyFry")
        {
			// Minus health
			TakeDamage(5);
        }
		
		if (obj.tag == "MyBox")
        {
			// Health Boost
			HealthBox(20);
			Destroy(obj.gameObject);
        }

		if (obj.tag == "Flag") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if (obj.tag == "Lava")
		{
			TakeDamage(10);
		}

		if (obj.tag == "Timer")
        {
            timer.TimerPickup(20);
			// Gets rid of timer object after player gets it
			Destroy((UnityEngine.Object)obj.gameObject);
        }

		if (obj.tag == "FallingSpike")
		{
			TakeDamage(5);
			Destroy(obj.gameObject);
		}

		if (obj.tag == "Blade")
		{
			TakeDamage(10);
		}

		if (obj.tag == "Magnet")
		{
			// Activate the coin magnet
			Collider2D[] nearbyCoins = Physics2D.OverlapCircleAll(transform.position, magnetRange);
			foreach (Collider2D coinCollider in nearbyCoins)
			{
				if (coinCollider.CompareTag("MyCoin"))
				{
					Vector2 direction = (transform.position - coinCollider.transform.position).normalized;
					coinCollider.GetComponent<Rigidbody2D>().AddForce(direction * magnetForce);
				}
			}
			Destroy(obj.gameObject);
		}

		if (obj.tag == "Dumbell")
		{
			CollectDumbell();
			Destroy(obj.gameObject); // Destroy the special item after collection
		}
    }

	private void CollectDumbell()
    {
        dumbellCollected++;
        CheckForBossDefeat();
    }

    private void CheckForBossDefeat()
    {
        if (dumbellCollected >= itemsNeededToDefeatBoss)
        {
            DefeatBoss();
        }
    }

	private void DefeatBoss()
	{
		GameObject boss = GameObject.FindGameObjectWithTag("Boss");
		if (boss != null)
		{
			// Instantiate the Flag prefab at the boss's position before destroying the boss
			if (flagPrefab != null)
			{
				Instantiate(flagPrefab, boss.transform.position, Quaternion.identity);
			}
			
			Destroy(boss); // Destroy the boss object
			dumbellCollected = 0; // Reset the count after defeating the boss
		}
	}

	private void UpdateCharacter(int selectedOption)
	{
		if (characterDB != null)
    	{
        	Character character = characterDB.GetCharacter(selectedOption);
        	if (character != null && artworkSprite != null)
        	{
            	artworkSprite.sprite = character.characterSprite;
        	}
        	else
        	{
            	Debug.LogError("character is null");
        	}
    	}
    	// else
    	// {
        // 	Debug.LogError("characterdatabase is null");
    	// }
	}

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
	

}
