using UnityEngine;
namespace SkillDataNamespace
{
    // �X�L���̊�{����ێ����A�X�L���̎�ނ������񋓌^���`���A�X�L���I�u�W�F�N�g�ɐݒ肷��X�N���v�^�u���I�u�W�F�N�g
    [CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObjects/Skill", order = 1)]
    public class SkillData : ScriptableObject
    {
        public string skillName; // �X�L����
        [Header("�X�L���̐���")]public string description; // �X�L���̐���
        public Sprite icon; // �X�L���̃A�C�R��
        public SkillType skillType; // �X�L���̎��
        public float cooldownTime; // �X�L���̃N�[���^�C��
    }


    // �X�L���̎�ނ������񋓌^
    public enum SkillType
    {
        Ranged,     // �������^
        Melee,      // �ߋ����^
        Buff        // ���ȃo�t�^
    }
}