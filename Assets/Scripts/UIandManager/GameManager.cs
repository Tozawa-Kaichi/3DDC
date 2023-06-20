using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition; // �����ʒu���w�肷�邽�߂�Transform�ϐ�
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
        //    // UI�}�l�[�W���[�̃C���X�^���X��o�^
        //    _UIMapManager = new UIMAPManager();
        //    ServiceLocator.RegisterService(_UIMapManager);
        //    DontDestroyOnLoad(gameObject);
        // �C�x���g���O���擾
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
            // spawnPosition���ݒ肳��Ă���ꍇ��_enemyPrefab�𐶐����A�w��ʒu�ɔz�u����
            if (spawnPosition != null)
            {
                GameObject enemyObject = Instantiate(_enemyPrefab[0], spawnPosition.position, Quaternion.identity);

                // Enemy�R���|�[�l���g���A�^�b�`����
                Enemy enemyComponent = enemyObject.GetComponent<Enemy>();
                if (enemyComponent == null)
                {
                    enemyComponent = enemyObject.AddComponent<Enemy>();
                }

                // �K�v�Ȃ��Enemy�R���|�[�l���g�ɑ΂��Ēǉ��̐ݒ�⏉�������s��

                // �������ꂽEnemy�I�u�W�F�N�g��Enemy�R���|�[�l���g���A�^�b�`����Ă��邱�Ƃ��m�F����
                if (enemyComponent == null)
                {
                    // Enemy�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�̃G���[�n���h�����O
                    Debug.LogError("EnemyPrefab��Enemy�R���|�[�l���g���A�^�b�`�ł��܂���ł���");
                }
            }
            else
            {
                // spawnPosition���ݒ肳��Ă��Ȃ��ꍇ�̃G���[�n���h�����O
                Debug.LogError("Spawn position is not set for enemy generation");
            }
        }

    }
}
