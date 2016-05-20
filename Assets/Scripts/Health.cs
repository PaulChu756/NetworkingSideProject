using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour
{
    /*
    Changes to the player’s current health should only be applied on the Server. 
    These changes are then synchronized on the Clients. This is called Server Authority. 
    For more information on Server Authority please see the page on Network System Concepts.
    To make our current health and damage system network aware and working under Server authority, 
    we need to use State Synchronization and a special member variable on networked objects called SyncVars. 
    Network synchronized variables, or SyncVars, are indicated with the attribute [SyncVar]. For more information on SyncVars, 
    please see the page on State Synchronization.

    This brings us to another tool for State Synchronization: the SyncVar hook. 
    SyncVar hooks will link a function to the SyncVar. 
    These functions are invoked on the Server and all Clients when the value of the SyncVar changes. 
    For more information on SyncVars and SyncVar hooks, please see the page on State Synchronization.
    */

    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("I'm dead");
        }
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
