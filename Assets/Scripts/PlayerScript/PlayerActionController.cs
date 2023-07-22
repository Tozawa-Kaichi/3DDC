using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] GameObject[] SkillEffects; // スキルエフェクトのゲームオブジェクト配列
    [SerializeField] Transform spawnPosition; // 生成位置

    [SerializeField]ArtsUIController artsUIController;

    private void Start()
    {
        // ArtsUIControllerコンポーネントを取得
        //artsUIController = ServiceLocator.GetService<ArtsUIController>();
    }

    private void Update()
    {
        int selectedIndex = artsUIController._selectedIndex;
        if(Input.GetButtonDown("Jump"))
        {
            if (selectedIndex >= 0 && selectedIndex < SkillEffects.Length)
            {
                // 選択されたスキルエフェクトを生成位置に生成
                GameObject skillEffect = SkillEffects[selectedIndex];
                Instantiate(skillEffect, spawnPosition.position, spawnPosition.rotation);
            }
        }
        
    }
}
