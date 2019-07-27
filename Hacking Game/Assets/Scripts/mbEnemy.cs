using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mbEnemy : MonoBehaviour
{
    #region Fields
    [Header("Leben")]

    [SerializeField]
    private float startHealth;
    private float health;

    public Image healthBar;

    #endregion

    private void Start()
    {
        health = startHealth;        
    }

    public void OnButtonDoDamage()
    {
        InflictDamage();
    }

    private void InflictDamage()
    {
        Debug.Log("Damage Taken");

        health -= startHealth * 0.1f;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
