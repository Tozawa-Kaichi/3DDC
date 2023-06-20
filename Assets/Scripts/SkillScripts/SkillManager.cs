using System.Collections.Generic;
using UnityEngine;

public class SkillManager:MonoBehaviour
{
    private Dictionary<SkillFactory.SkillType, SkillBase> skills; // �X�L���̎���

    public SkillManager()
    {
        skills = new Dictionary<SkillFactory.SkillType, SkillBase>();
    }

    /// <summary>
    /// �X�L����ǉ����܂��B
    /// </summary>
    /// <param name="skillType">�X�L���̎��</param>
    public void AddSkill(SkillFactory.SkillType skillType)
    {
        // SkillFactory���g�p���ăX�L���𐶐����A�����ɒǉ����܂�
        SkillBase skill = SkillFactory.CreateSkill((SkillFactory.SkillType)skillType);
        skills.Add(skillType, skill);
    }

    /// <summary>
    /// �X�L�����폜���܂��B
    /// </summary>
    /// <param name="skillType">�X�L���̎��</param>
    public void RemoveSkill(SkillFactory.SkillType skillType)
    {
        // ��������X�L�����폜���܂�
        skills.Remove(skillType);
    }

    /// <summary>
    /// �X�L�����g�p���܂��B
    /// </summary>
    /// <param name="skillType">�X�L���̎��</param>
    public void UseSkill(SkillFactory.SkillType skillType)
    {
        // �X�L���������ɑ��݂���ꍇ�A�g�p���܂�
        if (skills.ContainsKey(skillType))
        {
            SkillBase skill = skills[skillType];
            skill.Use();
        }
    }
    /// <summary>
    /// �w�肵���X�L���̃C���X�^���X���擾���܂��B
    /// </summary>
    /// <param name="skillType">�X�L���̎��</param>
    /// <returns>�X�L���̃C���X�^���X</returns>
    public SkillBase GetSkill(SkillFactory.SkillType skillType)
    {
        if (skills.ContainsKey(skillType))
        {
            return skills[skillType];
        }

        return null;
    }
    /// <summary>
    /// �������Ă���X�L���̎�ނ��擾���܂��B
    /// </summary>
    /// <returns>�������Ă���X�L���̎�ނ̃��X�g</returns>
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
