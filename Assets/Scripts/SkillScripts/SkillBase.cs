using SkillDataNamespace;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    protected SkillData skillData; // スキルの基本情報を保持するスクリプタブルオブジェクト

    protected bool isCooldown; // クールダウン中かどうかのフラグ
    protected float cooldownTime; // クールダウン時間
    public string skillName { get; protected set; } // スキル名のプロパティ
    public Sprite skillIcon { get; protected set; } // スキルアイコンのプロパティ
    // スキルの初期化を行うメソッド
    public virtual void Initialize(SkillData data)
    {
        skillData = data;
        isCooldown = false;
        cooldownTime = 0f;
    }

    // スキルの使用処理を行う仮想メソッド
    public abstract void Use();
}
