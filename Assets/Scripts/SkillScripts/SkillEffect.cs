using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public float lifetime = 2f; // �I�u�W�F�N�g�����ł���܂ł̎���

    private float timer; // �o�ߎ��Ԃ��v������^�C�}�[

    private void Update()
    {
        // �o�ߎ��Ԃ��X�V
        timer += Time.deltaTime;

        // �o�ߎ��Ԃ�lifetime�𒴂����ꍇ�A�I�u�W�F�N�g�����ł�����
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
