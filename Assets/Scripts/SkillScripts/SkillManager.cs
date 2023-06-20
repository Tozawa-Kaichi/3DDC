using System.Collections.Generic;
using UnityEngine;

public class SkillManager:MonoBehaviour
{
    private Dictionary<SkillFactory.SkillType, SkillBase> skills; // スキルの辞書

    public SkillManager()
    {
        skills = new Dictionary<SkillFactory.SkillType, SkillBase>();
    }

    /// <summary>
    /// スキルを追加します。
    /// </summary>
    /// <param name="skillType">スキルの種類</param>
    public void AddSkill(SkillFactory.SkillType skillType)
    {
        // SkillFactoryを使用してスキルを生成し、辞書に追加します
        SkillBase skill = SkillFactory.CreateSkill((SkillFactory.SkillType)skillType);
        skills.Add(skillType, skill);
    }

    /// <summary>
    /// スキルを削除します。
    /// </summary>
    /// <param name="skillType">スキルの種類</param>
    public void RemoveSkill(SkillFactory.SkillType skillType)
    {
        // 辞書からスキルを削除します
        skills.Remove(skillType);
    }

    /// <summary>
    /// スキルを使用します。
    /// </summary>
    /// <param name="skillType">スキルの種類</param>
    public void UseSkill(SkillFactory.SkillType skillType)
    {
        // スキルが辞書に存在する場合、使用します
        if (skills.ContainsKey(skillType))
        {
            SkillBase skill = skills[skillType];
            skill.Use();
        }
    }
    /// <summary>
    /// 指定したスキルのインスタンスを取得します。
    /// </summary>
    /// <param name="skillType">スキルの種類</param>
    /// <returns>スキルのインスタンス</returns>
    public SkillBase GetSkill(SkillFactory.SkillType skillType)
    {
        if (skills.ContainsKey(skillType))
        {
            return skills[skillType];
        }

        return null;
    }
    /// <summary>
    /// 所持しているスキルの種類を取得します。
    /// </summary>
    /// <returns>所持しているスキルの種類のリスト</returns>
    public List<SkillFactory.SkillType> GetOwnedSkills()
    {
        List<SkillFactory.SkillType> ownedSkillTypes = new List<SkillFactory.SkillType>();

        foreach (var skillType in skills.Keys)
        {
            ownedSkillTypes.Add(skillType);
        }

        return ownedSkillTypes;
    }
}
