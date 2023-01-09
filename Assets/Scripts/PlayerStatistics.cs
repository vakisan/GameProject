using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth = 100;
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private int currentExp = 0;
    [SerializeField]
    private int expRequired;

    public HealthBar healthBar;
    public ExpBar expBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        expRequired = calcExpRequired();
        expBar.SetMaxExp(expRequired);
    }

    void Update()
    {
        if (currentExp >= expRequired)
        {
            LevelUp();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
    }

    public void GainExp(int exp)
    {
        currentExp += exp;
        expBar.SetExp(currentExp);
    }

    public void LevelUp()
    {
        level++;
        currentExp -= expRequired;
        expBar.SetExp(currentExp);
        //Insert what stats increase upon level up.
        expRequired = calcExpRequired();
        expBar.SetMaxExp(expRequired);
    }

    public int calcExpRequired()
    {
        return level * 50;
    }
}
