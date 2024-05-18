using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterComponents
{
	public float timeBtwAttack;
	public float startTimeBtwAttack;
	
	public Transform attackPosition;
	public LayerMask whatIsEnemies;
	public float attackRange;
	public int attackDamage;
	
    protected override void HandleInput()
    {
        if(timeBtwAttack <= 0)
		{
			if(Input.GetKey(KeyCode.J))
			{
				animator.SetTrigger("Attack");
				Collider2D[] enemiesToattackDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
				for(int i=0; i<enemiesToattackDamage.Length; i++)
				{
					enemiesToattackDamage[i].GetComponent<Enemy>().TakeDamage(attackDamage);
				}			
				timeBtwAttack = startTimeBtwAttack;
			}
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}
    }
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPosition.position, attackRange);
	}			
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterComponents
{
	[SerializeField] private int damage;
	
    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.J))
        {
            Luffy_Attack();
        }
    }
	
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AI"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Luffy_Attack()
    {
        animator.SetTrigger("Attack");
    }
}
*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterComponents
{
	public float timeBtwAttack;
	public float startTimeBtwAttack;
	
	public Transform attackPosition;
	public LayerMask whatIsEnemies;
	public float attackRange;
	public int attackDamage;
	
    protected override void HandleInput()
    {
        if(timeBtwAttack <= 0)
		{
			if(Input.GetKey(KeyCode.J))
			{
				animator.SetTrigger("Attack");
				Collider2D[] enemiesToattackDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
				for(int i=0; i<enemiesToattackDamage.Length; i++)
				{
					enemiesToattackDamage[i].GetComponent<Health>().TakeDamage(attackDamage);
				}			
				timeBtwAttack = startTimeBtwAttack;
			}
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}
    }
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPosition.position, attackRange);
	}			
}
*/
    