using SkillDataNamespace;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    protected SkillData skillData; // �X�L���̊�{����ێ�����X�N���v�^�u���I�u�W�F�N�g

    protected bool isCooldown; // �N�[���_�E�������ǂ����̃t���O
    protected float cooldownTime; // �N�[���_�E������
    public string skillName { get; protected set; } // �X�L�����̃v���p�e�B
    public Sprite skillIcon { get; protected set; } // �X�L���A�C�R���̃v���p�e�B
    // �X�L���̏��������s�����\�b�h
    public virtual void Initialize(SkillData data)
    {
        skillData = data;
        isCooldown = false;
        cooldownTime = 0f;
    }

    // �X�L���̎g�p�������s�����z���\�b�h
    public abstract void Use();
}
