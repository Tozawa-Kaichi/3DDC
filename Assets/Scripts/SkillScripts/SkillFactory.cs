using System;

public class SkillFactory
{
    // �X�L���̎�ނ������񋓌^
    public enum SkillType
    {
        Ranged,
        Melee,
        Buff
    }
    // Factory Method �p�^�[����p���ăX�L���̐������s�����\�b�h
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
//���̃R�[�h�ł́ASkillFactory �N���X���X�L���̐�����S�����܂��BSkillType �񋓌^���g�p���ăX�L���̎�ނ��w�肵�AFactory Method �p�^�[����p���ēK�؂ȃX�L���N���X�̃C���X�^���X�𐶐����ĕԂ��܂��B

//�g�p��:

//SkillBase rangedSkill = SkillFactory.CreateSkill(SkillFactory.SkillType.Ranged);
//SkillBase meleeSkill = SkillFactory.CreateSkill(SkillFactory.SkillType.Melee);
//SkillBase buffSkill = SkillFactory.CreateSkill(SkillFactory.SkillType.Buff);
//����ɂ��ASkillFactory �N���X��ʂ��ăX�L���̐������s�����Ƃ��ł��܂��B�X�L���̎�ނɉ����ēK�؂ȃX�L���N���X�̃C���X�^���X���Ԃ���܂��B

//Factory Method �p�^�[���́A�N���X�̋�̓I�ȃC���X�^���X�����T�u�N���X�Ɉς˂邱�ƂŁA�_��Ɗg������񋟂��܂��B���̃p�^�[���ɂ��A�X�L���̎�ނ��������ꍇ�ł��A�V�����X�L���N���X��ǉ����邾���őΉ��ł��܂��B






