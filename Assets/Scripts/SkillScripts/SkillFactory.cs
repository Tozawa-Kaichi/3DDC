using System;

public class SkillFactory
{
    // スキルの種類を示す列挙型
    public enum SkillType
    {
        Ranged,
        Melee,
        Buff
    }
    // Factory Method パターンを用いてスキルの生成を行うメソッド
    public static SkillBase CreateSkill(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Ranged:
                return new RangedSkill();
            case SkillType.Melee:
                return new MeleeSkill();
            case SkillType.Buff:
                return new BuffSkill();
            default:
                throw new ArgumentException("Invalid skill type: " + skillType);
        }
    }
}
//このコードでは、SkillFactory クラスがスキルの生成を担当します。SkillType 列挙型を使用してスキルの種類を指定し、Factory Method パターンを用いて適切なスキルクラスのインスタンスを生成して返します。

//使用例:

//SkillBase rangedSkill = SkillFactory.CreateSkill(SkillFactory.SkillType.Ranged);
//SkillBase meleeSkill = SkillFactory.CreateSkill(SkillFactory.SkillType.Melee);
//SkillBase buffSkill = SkillFactory.CreateSkill(SkillFactory.SkillType.Buff);
//これにより、SkillFactory クラスを通じてスキルの生成を行うことができます。スキルの種類に応じて適切なスキルクラスのインスタンスが返されます。

//Factory Method パターンは、クラスの具体的なインスタンス化をサブクラスに委ねることで、柔軟性と拡張性を提供します。このパターンにより、スキルの種類が増えた場合でも、新しいスキルクラスを追加するだけで対応できます。






