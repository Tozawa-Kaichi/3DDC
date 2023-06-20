using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // 最大体力
    private int currentHealth; // 現在の体力

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 敵の死亡時の処理を実装する
        // 例: アニメーション再生、ポイント付与、アイテムドロップなど
        Destroy(gameObject);
    }
}
