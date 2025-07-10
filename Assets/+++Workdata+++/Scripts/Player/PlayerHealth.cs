using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6; // 3 Herzen = 6 halbe Herzen
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
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
        
    }
   
}

