using System.Collections;
using UnityEngine;

public class MeleeSkill : SkillBase, ISkillEffect
{
    [SerializeField] private float attackRange = 1.5f; // �U���͈�
    [SerializeField] private int damageAmount = 10; // �_���[�W��

    public override void Use()
    {
        if (!isCooldown)
        {
            // �U���͈͓��̓G���擾
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

            // �擾�����G�Ƀ_���[�W��^����
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
        // �ߋ����X�L���̏ꍇ�A�����蔻��Ȃǂ̒ǉ����ʂ͂����Ɏ������܂�
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
