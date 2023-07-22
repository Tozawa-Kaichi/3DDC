using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using SkillType = SkillFactory.SkillType;
//SkillFactory.SkillType��SkillType�Ƃ��ăG�C���A�X�i�ʖ��j���`
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject skillUIPrefab; // �X�L��UI�̃v���n�u
    [SerializeField] private Transform skillUIContainer; // �X�L��UI�̐e�I�u�W�F�N�g
    [SerializeField] private SkillManager skillManager; // �X�L���Ǘ��N���X�ւ̎Q��

    private Dictionary<SkillFactory.SkillType, GameObject> skillUIObjects = new Dictionary<SkillFactory.SkillType, GameObject>();

    private void Start()
    {
        CreateSkillUIs();
    }

    private void CreateSkillUIs()
    {
        // �X�L���Ǘ��N���X����v���C���[����������X�L���̃��X�g���擾
        List<SkillFactory.SkillType> ownedSkills = skillManager.GetOwnedSkills();

        foreach (SkillFactory.SkillType skillType in ownedSkills)
        {
            // �X�L���Ǘ��N���X���g�p���Ďw�肳�ꂽ�X�L���^�C�v�̃X�L�����擾
            SkillBase skill = skillManager.GetSkill(skillType);

            // �X�L��UI�̃v���n�u�𕡐����A�e�I�u�W�F�N�g�̉��ɔz�u
            GameObject skillUI = Instantiate(skillUIPrefab, skillUIContainer);

            // �X�L��UI�������ɒǉ����āA�X�L���^�C�v�Ɗ֘A�t����
            skillUIObjects.Add(skillType, skillUI);

            // �X�L��UI�̕\����������
            Text skillNameText = skillUI.GetComponentInChildren<Text>();
            skillNameText.text = skill.skillName; // �X�L������\��
            Image skillIconImage = skillUI.GetComponentInChildren<Image>();
            skillIconImage.sprite = skill.skillIcon; // �X�L���A�C�R����\��
            skillIconImage.fillAmount = 0f; // �N�[���_�E����Ԃ��������i0%�\���j
        }
    }

    public void UpdateSkillUI(SkillFactory.SkillType skillType, float cooldownTime, float remainingTime)
    {
        // �w�肳�ꂽ�X�L���^�C�v�ɑΉ�����X�L��UI���������ɑ��݂���ꍇ
        if (skillUIObjects.ContainsKey(skillType))
        {
            // �X�L��UI���擾
            GameObject skillUI = skillUIObjects[skillType];

            // �X�L���A�C�R���̃C���[�W�R���|�[�l���g���擾
            Image skillIconImage = skillUI.GetComponentInChildren<Image>();

            // �N�[���_�E����Ԃ��X�V�i�N�[���_�E�����Ԃɑ΂���c�莞�Ԃ̊������v�Z�j
            float fillAmount = remainingTime / cooldownTime;

            // �X�L���A�C�R���̕\�����X�V
            skillIconImage.fillAmount = fillAmount;
        }
    }
}
