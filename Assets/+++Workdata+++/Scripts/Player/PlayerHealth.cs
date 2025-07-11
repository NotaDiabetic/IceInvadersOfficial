using System;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6; // 3 Herzen = 6 halbe Herzen
    public int currentHealth;
    [SerializeField] Pause_Manager pauseManager;
    [SerializeField] SnowballCatcher sbc;

    public GameObject Heart1Full;
    public GameObject Heart2Full;
    public GameObject Heart3Full;
    public GameObject Heart1Half;
    public GameObject Heart2Half;
    public GameObject Heart3Half;
    public GameObject HighlightSimple;
    public GameObject HighlightMedium;
    public GameObject HighlightHeavy;



    void Start()
    {
        currentHealth = maxHealth;
        Heart1Full.SetActive(true);
        Heart2Full.SetActive(true);
        Heart3Full.SetActive(true);
        Heart1Half.SetActive(true);
        Heart2Half.SetActive(true);
        Heart3Half.SetActive(true);
        HighlightSimple.SetActive(true);
        HighlightMedium.SetActive(false);
        HighlightHeavy.SetActive(false);
        
    }

    void Update()
    {
        if (currentHealth <= 5)
        {
            Heart3Full.SetActive(false);
        }
        if (currentHealth <= 4)
        {
            Heart3Half.SetActive(false);
        }
        if (currentHealth <= 3)
        {
            Heart2Full.SetActive(false);
        }
        if (currentHealth <= 2)
        {
            Heart2Half.SetActive(false);
        }
        if (currentHealth <= 1)
        {
            Heart1Full.SetActive(false);
        }
        if (sbc.ProjectileType == 0)
        {
            HighlightSimple.SetActive(true);
            HighlightMedium.SetActive(false);
            HighlightHeavy.SetActive(false);
        }
        if (sbc.ProjectileType == 1)
        {
            HighlightSimple.SetActive(false);
            HighlightMedium.SetActive(true);
            HighlightHeavy.SetActive(false);
        }
        if (sbc.ProjectileType == 2)
        {
            HighlightSimple.SetActive(false);
            HighlightMedium.SetActive(false);
            HighlightHeavy.SetActive(true);
        }
    }

    public void TakeSimpleDamage(int simpleDamage = 1)
    {

        currentHealth -= simpleDamage; // Schaden abziehen

        Debug.Log("Spieler hat Schaden genommen: " + simpleDamage + " → Aktuelle Lebenspunkte: " + currentHealth + " / " + maxHealth);
    }

    public void TakeMediumDamage(int mediumDamage = 2)
    {

        currentHealth -= mediumDamage; // Schaden abziehen

        Debug.Log("Spieler hat Schaden genommen: " + mediumDamage + " → Aktuelle Lebenspunkte: " + currentHealth + " / " + maxHealth);

    }

    public void TakeHardDamage(int hardDamage = 3)
    {

        currentHealth -= hardDamage; // Schaden abziehen

        Debug.Log("Spieler hat Schaden genommen: " + hardDamage + " → Aktuelle Lebenspunkte: " + currentHealth + " / " + maxHealth);


    }
    public void Die()
    {
        Debug.Log("Spieler ist tot!");
        pauseManager.LoseGame();
        
    }
   
}

