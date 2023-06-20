using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition; // 生成位置を指定するためのTransform変数
    [SerializeField] GameObject[] _enemyPrefab;
    private static GameManager instance;
    //private UIMAPManager _UIMapManager;
    private string _eventName;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    private void Awake()
    {
        //    // UIマネージャーのインスタンスを登録
        //    _UIMapManager = new UIMAPManager();
        //    ServiceLocator.RegisterService(_UIMapManager);
        //    DontDestroyOnLoad(gameObject);
        // イベント名前を取得
        _eventName = ServiceLocator.GetService<string>();
    }
    private void Start()
    {
        _eventName = "Sword";
        Debug.Log(_eventName);
        GenerateObjectBasedOnName();
    }
    private void Update()
    {

    }
    private void GenerateObjectBasedOnName()
    {
        if (_eventName == "Sword")
        {
            // spawnPositionが設定されている場合に_enemyPrefabを生成し、指定位置に配置する
            if (spawnPosition != null)
            {
                GameObject enemyObject = Instantiate(_enemyPrefab[0], spawnPosition.position, Quaternion.identity);

                // Enemyコンポーネントをアタッチする
                Enemy enemyComponent = enemyObject.GetComponent<Enemy>();
                if (enemyComponent == null)
                {
                    enemyComponent = enemyObject.AddComponent<Enemy>();
                }

                // 必要ならばEnemyコンポーネントに対して追加の設定や初期化を行う

                // 生成されたEnemyオブジェクトにEnemyコンポーネントがアタッチされていることを確認する
                if (enemyComponent == null)
                {
                    // Enemyコンポーネントがアタッチされていない場合のエラーハンドリング
                    Debug.LogError("EnemyPrefabにEnemyコンポーネントをアタッチできませんでした");
                }
            }
            else
            {
                // spawnPositionが設定されていない場合のエラーハンドリング
                Debug.LogError("Spawn position is not set for enemy generation");
            }
        }

    }
}
