using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHealth : Collectables
{
[SerializeField] private int healthToAdd = 1;
[SerializeField] private ParticleSystem healthBonus;
    
    protected override void Pick()
    {
        AddHealth();    
    }

    protected override void PlayEffects()
    {
        Instantiate(healthBonus, transform.position, Quaternion.identity);
    }

    public void AddHealth()
{
        if (character != null)
    {
            character.GetComponent<Health>().GainHealth(healthToAdd);
        }
    }
}
//.........