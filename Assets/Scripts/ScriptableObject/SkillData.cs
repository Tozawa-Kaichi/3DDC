using UnityEngine;
namespace SkillDataNamespace
{
    // スキルの基本情報を保持し、スキルの種類を示す列挙型を定義し、スキルオブジェクトに設定するスクリプタブルオブジェクト
    [CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObjects/Skill", order = 1)]
    public class SkillData : ScriptableObject
    {
        public string skillName; // スキル名
        [Header("スキルの説明")]public string description; // スキルの説明
        public Sprite icon; // スキルのアイコン
        public SkillType skillType; // スキルの種類
        public float cooldownTime; // スキルのクールタイム
    }


    // スキルの種類を示す列挙型
    public enum SkillType
    {
        Ranged,     // 遠距離型
        Melee,      // 近距離型
        Buff        // 自己バフ型
    }
}