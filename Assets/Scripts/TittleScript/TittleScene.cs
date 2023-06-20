using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TittleScene : MonoBehaviour
{
    [SerializeField] Animator _cameraAnimator;
    [SerializeField] UnityEvent _onTitleUIShown;
    [SerializeField] GameObject _pleasePressUI;
    [SerializeField] float _waitsecond;
    bool _pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        _pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
           _pressed = true;
        }
        if(_pressed)
        {
            _pleasePressUI.SetActive(false);
            _cameraAnimator.SetTrigger("Pressed");
            Invoke(nameof(Pressed),_waitsecond);
        }
    }
    void Pressed()
    {
        _onTitleUIShown.Invoke();

        _pressed = false;
        
    }
}
