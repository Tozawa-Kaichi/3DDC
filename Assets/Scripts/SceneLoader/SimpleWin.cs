using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SimpleWin : MonoBehaviour
{

    void Start()
    {
        // �V�[�����̑S�ẴI�u�W�F�N�g���擾
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // �I�u�W�F�N�g���P���m�F���A�����ƃ��C�g�ƃJ�����ȊO�͔j�󂷂�
        foreach (GameObject obj in allObjects)
        {
            if (obj != this.gameObject && obj.GetComponent<Light>() == null && obj.GetComponent<Camera>() == null)
            {
                Destroy(obj);
            }
        }
    }
    void OnDestroy()
    {
        // ���g���j�󂳂ꂽ�猻�݂̃V�[�����ēǂݍ��݂���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
