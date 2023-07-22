using UnityEngine;
using System.Collections;
public class BuffSkill : SkillBase, ISkillEffect
{
    [SerializeField] private float buffDuration = 5f; // �o�t�̎�������
    [SerializeField] private float movementSpeedMultiplier = 1.5f; // �ړ����x�{��
    [SerializeField] private float attackDamageMultiplier = 1.5f; // �U���_���[�W�{��

    private Coroutine buffCoroutine; // �o�t���ʂ̃R���[�`��

    public override void Use()
    {
        if (!isCooldown)
        {
            ApplyBuffEffect();

            isCooldown = true;
            cooldownTime = skillData.cooldownTime;

            StartCoroutine(ResetCooldown());
        }
    }

    public void ApplyEffect()
    {
        // BuffSkill�̏ꍇ�A���ʓK�p�̎����͕K�v�Ȃ�
    }

    private void ApplyBuffEffect()
    {
        if (buffCoroutine != null)
        {
            StopCoroutine(buffCoroutine);
        }

        buffCoroutine = StartCoroutine(BuffDurationCoroutine());
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }

    private IEnumerator BuffDurationCoroutine()
    {
        PlayerMoveController playerController = ServiceLocator.GetService<PlayerMoveController>();
        float originalSpeed = playerController.EffectiveMoveSpeed;
        float originalMultiplier = playerController.MoveSpeedMultiplier;

        // �\�͂��ꎞ�I�ɕύX
        playerController.MoveSpeedMultiplier *= movementSpeedMultiplier;

        yield return new WaitForSeconds(buffDuration);

        // �o�t���ʂ̏I�����A�\�͂����ɖ߂�
        playerController.MoveSpeedMultiplier = originalMultiplier;
        // ���̔\�͕ύX�̌��ɖ߂������������ɒǉ�����

        buffCoroutine = null;
    }
}
