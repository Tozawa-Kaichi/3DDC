using UnityEngine;
using System.Collections;
public class BuffSkill : SkillBase, ISkillEffect
{
    [SerializeField] private float buffDuration = 5f; // バフの持続時間
    [SerializeField] private float movementSpeedMultiplier = 1.5f; // 移動速度倍率
    [SerializeField] private float attackDamageMultiplier = 1.5f; // 攻撃ダメージ倍率

    private Coroutine buffCoroutine; // バフ効果のコルーチン

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
        // BuffSkillの場合、効果適用の実装は必要ない
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

        // 能力を一時的に変更
        playerController.MoveSpeedMultiplier *= movementSpeedMultiplier;

        yield return new WaitForSeconds(buffDuration);

        // バフ効果の終了時、能力を元に戻す
        playerController.MoveSpeedMultiplier = originalMultiplier;
        // 他の能力変更の元に戻す処理もここに追加する

        buffCoroutine = null;
    }
}
