using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    /*
    Changes to the player’s current health should only be applied on the Server. 
    These changes are then synchronized on the Clients. This is called Server Authority. 
    For more information on Server Authority please see the page on Network System Concepts.
    To make our current health and damage system network aware and working under Server authority, 
    we need to use State Synchronization and a special member variable on networked objects called SyncVars. 
    Network synchronized variables, or SyncVars, are indicated with the attribute [SyncVar]. For more information on SyncVars, 
    please see the page on State Synchronization.
    */

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("I'm dead");
        }

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
}
