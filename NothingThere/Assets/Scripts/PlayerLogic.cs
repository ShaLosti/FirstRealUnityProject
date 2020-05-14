using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private int baseMaxHealth;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Start()
    {
        GameManager.savePointPosition = transform;
        baseMaxHealth = MaxHealth;
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
    }

    private void CheckValues()
    {
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        if (CurrentHealth < 0) CurrentHealth = 0;
    }

    private void UpdateHealthBar()
    {
        CheckValues();
        UIController.SetMaxUIFillHealth(MaxHealth);
        UIController.SetUIFillHealth(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            GameManager.GameOver();
        }
    }

    public void AddHP(int hp)
    {
        this.CurrentHealth = this.CurrentHealth + hp;
        UpdateHealthBar();
    }

    public void AddMaxHP(int hp)
    {
        this.MaxHealth = this.MaxHealth + hp;
        UpdateHealthBar();
    }

    public void UpdateBaseMaxHealth(int value)
    {
        baseMaxHealth = value;
    }

    public void DefaultValues()
    {
        MaxHealth = baseMaxHealth;
        CurrentHealth = MaxHealth;
        CheckValues();
        UpdateHealthBar();
    }
}
