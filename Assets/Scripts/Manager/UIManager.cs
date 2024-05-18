using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;	

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private TextMeshProUGUI currentShieldTMP;

    [Header("Weapon")]
    [SerializeField] private TextMeshProUGUI currentAmmoTMP;
    [SerializeField] private Image weaponImage;

    [Header("Text")] 
[SerializeField] private TextMeshProUGUI coinsTMP;

    //[Header("Boss")] 
   // [SerializeField] private Image bossHealth;

    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerMaxShield;
    private float playerCurrentShield;
    private bool isPlayer;

    private int playerCurrentAmmo;
	private int playerMaxAmmo;

    private float bossCurrentHealth;
    private float bossMaxHealth;

    private void Update()
    {
        InternalUpdate();
    }
    
    public void UpdateHealth(float currentHealth, float maxHealth, float currentShield, float maxShield , bool isThisMyPlayer)
    { 
        playerCurrentHealth = currentHealth;
        playerMaxHealth = maxHealth; 
        playerCurrentShield = currentShield;
        playerMaxShield = maxShield;
        isPlayer = isThisMyPlayer;       
	}

    public void UpdateBossHealth(float currentHealth, float maxHealth)
    {
        bossCurrentHealth = currentHealth;
        bossMaxHealth = maxHealth;
    }


    public void UpdateWeaponSprite(Sprite weaponSprite)
    { 
        weaponImage.sprite = weaponSprite;
        weaponImage.SetNativeSize();
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        playerCurrentAmmo = currentAmmo;
        playerMaxAmmo = maxAmmo;
    }
	

    private void InternalUpdate()
    {
        if (isPlayer)
        {        
           healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
           currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString(); 

           shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, playerCurrentShield / playerMaxShield, 10f * Time.deltaTime);
           currentShieldTMP.text = playerCurrentShield.ToString() + "/" + playerMaxShield.ToString();
        }

         //Update Ammo
        currentAmmoTMP.text = playerCurrentAmmo + " / " + playerMaxAmmo;    

         //Update Coins
        coinsTMP.text = CoinManager.Instance.Coins.ToString(); 

        // Update Boss Health
        //bossHealth.fillAmount = Mathf.Lerp(bossHealth.fillAmount, bossCurrentHealth / bossMaxHealth, 10f * Time.deltaTime);
    }
} 
