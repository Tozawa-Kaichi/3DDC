using System.Collections;
using UnityEngine;

public class MeleeSkill : SkillBase, ISkillEffect
{
    [SerializeField] private float attackRange = 1.5f; // 攻撃範囲
    [SerializeField] private int damageAmount = 10; // ダメージ量

    public override void Use()
    {
        if (!isCooldown)
        {
            // 攻撃範囲内の敵を取得
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

            // 取得した敵にダメージを与える
            foreach (Collider collider in hitColliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damageAmount);
                }
            }

            isCooldown = true;
            cooldownTime = skillData.cooldownTime;

            StartCoroutine(ResetCooldown());
        }
    }

    public void ApplyEffect()
    {
        // 近距離スキルの場合、当たり判定などの追加効果はここに実装します
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
