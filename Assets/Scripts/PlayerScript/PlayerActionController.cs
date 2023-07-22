using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] GameObject[] SkillEffects; // �X�L���G�t�F�N�g�̃Q�[���I�u�W�F�N�g�z��
    [SerializeField] Transform spawnPosition; // �����ʒu

    [SerializeField]ArtsUIController artsUIController;

    private void Start()
    {
        // ArtsUIController�R���|�[�l���g���擾
        //artsUIController = ServiceLocator.GetService<ArtsUIController>();
    }

    private void Update()
    {
        int selectedIndex = artsUIController._selectedIndex;
        if(Input.GetButtonDown("Jump"))
        {
            if (selectedIndex >= 0 && selectedIndex < SkillEffects.Length)
            {
                // �I�����ꂽ�X�L���G�t�F�N�g�𐶐��ʒu�ɐ���
                GameObject skillEffect = SkillEffects[selectedIndex];
                Instantiate(skillEffect, spawnPosition.position, spawnPosition.rotation);
            }
        }
        
    }
}
