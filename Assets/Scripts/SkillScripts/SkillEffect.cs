using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public float lifetime = 2f; // オブジェクトが消滅するまでの時間

    private float timer; // 経過時間を計測するタイマー

    private void Update()
    {
        // 経過時間を更新
        timer += Time.deltaTime;

        // 経過時間がlifetimeを超えた場合、オブジェクトを消滅させる
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
