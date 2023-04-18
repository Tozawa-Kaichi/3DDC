using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleWin : MonoBehaviour
{
    public string textToDisplay = "åÀ‡VÇÃèüÇø";
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Debug.Log(mainCamera);
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj != gameObject && obj.tag != "MainCamera")
            {
                obj.SetActive(false);
            }
        }

        Vector3 camPos = mainCamera.transform.position;
        Vector3 camForward = mainCamera.transform.forward;
        Vector3 textPos = camPos + camForward * 5f;

        GameObject textObj = new GameObject("TextObject");
        textObj.transform.position = textPos;
        textObj.transform.LookAt(camPos);

        Text textComp = textObj.AddComponent<Text>();
        textObj.AddComponent<Canvas>();
        textComp.text = textToDisplay;
        textComp.fontSize = 100;
        textComp.color = Color.white;

        RectTransform rectTrans = textObj.GetComponent<RectTransform>();
        rectTrans.sizeDelta = new Vector2(1000, 300);
    }

    void Update()
    {
        
    }
}
