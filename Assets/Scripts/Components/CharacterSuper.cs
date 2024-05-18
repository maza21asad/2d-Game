using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSuper : CharacterComponents
{
    public float timeBtwSuper;
	public float starttimeBtwSuper;
	
	public Transform superPosition;
	public LayerMask whatIsEnemies;
	public float superRange;
	public int superDamage;
	
    protected override void HandleInput()
    {
        if(timeBtwSuper <= 0)
		{
			if(Input.GetKey(KeyCode.K))
			{
				animator.SetTrigger("Super");
				Collider2D[] enemiesTosuperDamage = Physics2D.OverlapCircleAll(superPosition.position, superRange, whatIsEnemies);
				for(int i=0; i<enemiesTosuperDamage.Length; i++)
				{
					enemiesTosuperDamage[i].GetComponent<Enemy>().TakeDamage(superDamage);
				}
				timeBtwSuper = starttimeBtwSuper;
			}
		}
		else
		{
			timeBtwSuper -= Time.deltaTime;
		}
    }
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(superPosition.position, superRange);
	}	
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSuper : CharacterComponents
{
	//[SerializeField] private int damage;
	
    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Luffy_Super();
        }
    }
	
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AI"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Luffy_Super()
    {
        animator.SetTrigger("Super");
    }
}
*/