using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // �ő�̗�
    private int currentHealth; // ���݂̗̑�

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
        // �G�̎��S���̏�������������
        // ��: �A�j���[�V�����Đ��A�|�C���g�t�^�A�A�C�e���h���b�v�Ȃ�
        Destroy(gameObject);
    }
}
