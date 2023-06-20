using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Å‘å‘Ì—Í
    [SerializeField] private int currentHealth = 100; // Œ»Ý‚Ì‘Ì—Í
    [SerializeField] private int coins = 0; // ŠŽ‹à

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public int Coins => coins;

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void ModifyCoins(int amount)
    {
        coins += amount;
        coins = Mathf.Max(coins, 0);
    }
}
