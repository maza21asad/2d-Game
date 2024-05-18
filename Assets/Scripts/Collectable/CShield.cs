using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShield : Collectables
{
    [SerializeField] private int shieldToAdd = 1;
    [SerializeField] private ParticleSystem shieldEffect;

    protected override void Pick()
    {
        AddShield();
    }

    protected override void PlayEffects()
    {
        Instantiate(shieldEffect, transform.position, Quaternion.identity);
    }

    public void AddShield()
    {
        if (character != null)
		  {
            character.GetComponent<Health>().GainShield(shieldToAdd);
        }
    }
}
