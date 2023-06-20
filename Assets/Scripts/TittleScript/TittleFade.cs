using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TittleFade : MonoBehaviour
{
    [SerializeField] float _waitsecond;//アニメーションによらず待つ秒数
    public void TitleLoad(string name)
    {
        StartCoroutine(LoadScene(name));
    }
    public IEnumerator LoadScene(string name)
    {
        //後で使う
        //yield return new WaitUntil(() => Triger._canFadeOut);//フェードする画像の方のBoolがtrueにならない限りここで待ってくれる
        yield return new WaitForSeconds(_waitsecond);//アニメーションが終わった後指定した秒数待ってくれる
        SceneManager.LoadScene(name);
    }
}