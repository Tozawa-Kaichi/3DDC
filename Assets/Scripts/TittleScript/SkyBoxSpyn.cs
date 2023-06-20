using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// スカイボックスを回転させるスクリプト
/// </summary>
public class SkyBoxSpyn : MonoBehaviour
{
    [Range(0.01f, 0.1f)]
    [SerializeField] float _spinSpeed = 0;

    Material _skybox = default;
    float _spinRepeatValue = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _skybox = RenderSettings.skybox;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_skybox)
        {
            _skybox = RenderSettings.skybox;
        }
        _spinRepeatValue = Mathf.Repeat(_skybox.GetFloat("_Rotation") + _spinSpeed, 360f);//第一引数 を 第二引数で割った余りを返し続ける
        _skybox.SetFloat("_Rotation", _spinRepeatValue);
    }

}
