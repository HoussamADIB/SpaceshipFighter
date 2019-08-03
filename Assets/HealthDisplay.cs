using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int health;
    private int healthMax;
    private bool initiated=false;
    public Image healthBar;
    void Update()
    {
        if (initiated) healthBar.fillAmount = (float) health / healthMax;

    }
    public void initiate(int healthMax)
    {
        initiated = true;
        this.healthMax = healthMax;
        health = healthMax;
    }


    public int Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        return health;
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
    }
}
