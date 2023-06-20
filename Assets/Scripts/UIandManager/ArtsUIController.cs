using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class ArtsUIController : MonoBehaviour
{
    [SerializeField] private int _count = 5;
    private GameObject[] _cells;
    public int _selectedIndex;
    [SerializeField] List<Sprite> _knightArtsImage;
    [SerializeField] List<Sprite> _wizardArtsImage;
    [SerializeField] List<Sprite> _rogueArtsImage;
    private void Start()
    {
        _cells = new GameObject[_count];
        for (var i = 0; i < _cells.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;
            obj.AddComponent<Image>();
            //Image objImage = obj.GetComponent<Image>();
            //if (i >=1)
            //{
            //    if (FadeSceneLoader.currentCharacter == "SelectKnight")
            //    {
            //        objImage = _knightArtsImage[i].;
            //    }
            //    else if (FadeSceneLoader.currentCharacter == "SelectRogue")
            //    {
            //        objImage = _rogueArtsImage[i];
            //    }
            //    else if (FadeSceneLoader.currentCharacter == "SelectWizzard")
            //    {
            //        objImage = _wizardArtsImage[i];
            //    }
            //}

            _cells[i] = obj;
        }
        OnSelectedChanged();
    }

    private void Update()
    {
        var V =
            (Input.GetAxis("Mouse ScrollWheel") > 0 ? -1 : 0) +
            (Input.GetAxis("Mouse ScrollWheel") < 0 ? 1 : 0);
        if (V != 0) // ¶ƒL[‚ð‰Ÿ‚µ‚½
        {
            _selectedIndex += V;
            OnSelectedChanged();
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var cell = _cells[_selectedIndex];
        //    Destroy(cell);
        //    OnSelectedChanged();
        //}
        Normalized();
    }

    private void OnSelectedChanged()
    {
        for (var i = 0; i < _cells.Length; i++)
        {
            var cell = _cells[i];
            if (!cell) { continue; }
            var image = cell.GetComponent<Image>();
            if (i == _selectedIndex)
            {
                image.color = Color.red;
            }
            else
            {
                image.color = Color.white;
            }
        }
    }
    void Normalized()
    {
        if (_selectedIndex < 0)
            _selectedIndex = 0;
        if (_selectedIndex > _cells.Length - 1)
            _selectedIndex = _cells.Length - 1;
        OnSelectedChanged();
    }
}