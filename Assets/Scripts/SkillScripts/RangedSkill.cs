using UnityEngine;
using System.Collections;
public class RangedSkill : SkillBase, ISkillEffect
{
    [SerializeField] GameObject projectilePrefab; // �ˏo���̃v���n�u

    public override void Use()
    {
        if (!isCooldown)
        {
            // �ˏo���𐶐����A�O���Ɏˏo���鏈��
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // �����Ŏˏo���ɕK�v�Ȑݒ����ʂ�ǉ�����\��������܂�

            // �N�[���_�E���̐ݒ�
            isCooldown = true;
            cooldownTime = skillData.cooldownTime;

            // ��莞�Ԍ�ɃN�[���_�E������������R���[�`�����J�n
            StartCoroutine(ResetCooldown());
        }
    }

    public void ApplyEffect()
    {
        // �ˏo���̌��ʂ�K�p���鏈��
        // �Ⴆ�΁A�ˏo�����G�ɓ��������ꍇ�̃_���[�W�����������ʂ̓K�p�Ȃǂ��s���܂�
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
