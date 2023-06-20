using UnityEngine;
using System.Collections;
public class RangedSkill : SkillBase, ISkillEffect
{
    [SerializeField] GameObject projectilePrefab; // 射出物のプレハブ

    public override void Use()
    {
        if (!isCooldown)
        {
            // 射出物を生成し、前方に射出する処理
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // ここで射出物に必要な設定や効果を追加する可能性があります

            // クールダウンの設定
            isCooldown = true;
            cooldownTime = skillData.cooldownTime;

            // 一定時間後にクールダウンを解除するコルーチンを開始
            StartCoroutine(ResetCooldown());
        }
    }

    public void ApplyEffect()
    {
        // 射出物の効果を適用する処理
        // 例えば、射出物が敵に当たった場合のダメージ処理や特殊効果の適用などを行います
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
