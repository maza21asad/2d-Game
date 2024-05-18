using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLongAttack : CharacterComponents
{
    public float timeBtwlongAttack;
	public float startTimeBtwlongAttack;
	
	public Transform longAttackPosition;
	public LayerMask whatIsEnemies;
	public float longAttackRange;
	public int longAttackDamage;
	
    protected override void HandleInput()
    {
        if(timeBtwlongAttack <= 0)
		{
			if(Input.GetKey(KeyCode.L))
			{
				animator.SetTrigger("LongAttack");
				Collider2D[] enemiesTolongAttackDamage = Physics2D.OverlapCircleAll(longAttackPosition.position, longAttackRange, whatIsEnemies);
				for(int i=0; i<enemiesTolongAttackDamage.Length; i++)
				{
					enemiesTolongAttackDamage[i].GetComponent<Enemy>().TakeDamage(longAttackDamage);
				}
				timeBtwlongAttack = startTimeBtwlongAttack;
			}			
		}
		else
		{
			timeBtwlongAttack -= Time.deltaTime;
		}
    }
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(longAttackPosition.position,longAttackRange);
	}
}


/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLongAttack : CharacterComponents
{
	[SerializeField] private int damage;
	
    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Luffy_LongAttack();
        }
    }
	
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AI"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Luffy_LongAttack()
    {
        animator.SetTrigger("LongAttack");
    }
}
*/