using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using SkillType = SkillFactory.SkillType;
//SkillFactory.SkillTypeをSkillTypeとしてエイリアス（別名）を定義
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject skillUIPrefab; // スキルUIのプレハブ
    [SerializeField] private Transform skillUIContainer; // スキルUIの親オブジェクト
    [SerializeField] private SkillManager skillManager; // スキル管理クラスへの参照

    private Dictionary<SkillFactory.SkillType, GameObject> skillUIObjects = new Dictionary<SkillFactory.SkillType, GameObject>();

    private void Start()
    {
        CreateSkillUIs();
    }

    private void CreateSkillUIs()
    {
        // スキル管理クラスからプレイヤーが所持するスキルのリストを取得
        List<SkillFactory.SkillType> ownedSkills = skillManager.GetOwnedSkills();

        foreach (SkillFactory.SkillType skillType in ownedSkills)
        {
            // スキル管理クラスを使用して指定されたスキルタイプのスキルを取得
            SkillBase skill = skillManager.GetSkill(skillType);

            // スキルUIのプレハブを複製し、親オブジェクトの下に配置
            GameObject skillUI = Instantiate(skillUIPrefab, skillUIContainer);

            // スキルUIを辞書に追加して、スキルタイプと関連付ける
            skillUIObjects.Add(skillType, skillUI);

            // スキルUIの表示を初期化
            Text skillNameText = skillUI.GetComponentInChildren<Text>();
            skillNameText.text = skill.skillName; // スキル名を表示
            Image skillIconImage = skillUI.GetComponentInChildren<Image>();
            skillIconImage.sprite = skill.skillIcon; // スキルアイコンを表示
            skillIconImage.fillAmount = 0f; // クールダウン状態を初期化（0%表示）
        }
    }

    public void UpdateSkillUI(SkillFactory.SkillType skillType, float cooldownTime, float remainingTime)
    {
        // 指定されたスキルタイプに対応するスキルUIが辞書内に存在する場合
        if (skillUIObjects.ContainsKey(skillType))
        {
            // スキルUIを取得
            GameObject skillUI = skillUIObjects[skillType];

            // スキルアイコンのイメージコンポーネントを取得
            Image skillIconImage = skillUI.GetComponentInChildren<Image>();

            // クールダウン状態を更新（クールダウン時間に対する残り時間の割合を計算）
            float fillAmount = remainingTime / cooldownTime;

            // スキルアイコンの表示を更新
            skillIconImage.fillAmount = fillAmount;
        }
    }
}
