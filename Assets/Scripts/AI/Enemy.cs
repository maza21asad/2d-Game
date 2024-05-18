using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float currentHealth;
	public float walkSpeed;
	public int enemy_damage;
	public float timeBtwEnemy;
	public float enemy_alterTime;
	public float enemyRadius;
	
	public Transform enemyRange;
	public LayerMask whatIsPlayer;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.left*walkSpeed*Time.deltaTime, Space.World);
		if(timeBtwEnemy<0)
		{
			Collider2D[] playerInEnemy = Physics2D.OverlapCircleAll(enemyRange.position, enemyRadius, whatIsPlayer);
			for(int i=0; i<playerInEnemy.Length; i++)
			{
				playerInEnemy[i].GetComponent<Health>().TakeDamage(enemy_damage);
			}	
			timeBtwEnemy = enemy_alterTime;
		}
		else
		{
			timeBtwEnemy -= Time.deltaTime;
		}		
    }
	
	public void TakeDamage(int damage)
	{
		if (currentHealth <= 0)
        {
            return;
        }
        
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
	}
	
	private void Die()
	{
       gameObject.SetActive(false);
    }
}
