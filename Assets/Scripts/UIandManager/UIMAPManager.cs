using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMAPManager : MonoBehaviour
{
    static int _floorcount =0;
    string _eventName = null;
    [SerializeField] float _fadeWaitTime;
    [SerializeField] Text _floorCountUI;
    [SerializeField] Image _lefteventimages;
    [SerializeField] Image _righteventimages;
    [SerializeField] Sprite[] _eventsprites;
    [SerializeField] GameObject _fadeUI;
    // Start is called before the first frame update
    void Start()
    {
        _floorcount++;
        _floorCountUI.text = _floorcount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Sprite GetRandomImage()
    {
        if (_eventsprites != null && _eventsprites.Length > 0)
        {
            int randomIndex = Random.Range(0, _eventsprites.Length);
            return _eventsprites[randomIndex];
        }
        else
        {
            Debug.LogWarning("Image array is empty!");
            return null;
        }
    }
    public void SetImageToLeftCard()
    {
        _lefteventimages.sprite = GetRandomImage();
        _eventName = _lefteventimages.sprite.name;
        ServiceLocator.RegisterService<string>(_eventName);
        Invoke(nameof(FadeImageSetActive), _fadeWaitTime);
    }
    public void SetImageToRightCard()
    {
        _righteventimages.sprite = GetRandomImage();
        _eventName = _righteventimages.sprite.name;
        ServiceLocator.RegisterService<string>(_eventName);
        Invoke(nameof(FadeImageSetActive), _fadeWaitTime);
    }
    public void FloorCountUP()
    {
        _floorcount++;
    }
    void FadeImageSetActive()
    {
        _fadeUI.SetActive(true);
    }
}
