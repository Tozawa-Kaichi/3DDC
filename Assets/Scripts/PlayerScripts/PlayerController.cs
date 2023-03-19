using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player�̓����𐧌䂷��R���|�[�l���g
/// �X�}�z�ړ��ɑΉ����������͒m���̂Ŋw�K���Ă�O�̃v���W�F�N�g�̃X�N���v�g���Q�l�ɂ���
/// �v���C���[�ɕK�v�ȋ����̓A�N�V�����ƈړ��Ƃ���Ă邪�A�N�V�����ĂȂ��˂�
/// �ʓ|������ʃX�N���v�g�ł��̋@�\�͍�邪�Â������͍̂���
/// ���ꂭ�炢�����΂������i�K���j
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick _joyStick;
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody2D _rb2D;
    float _h;
    float _v;
    private void Update()
    {
        _h = _joyStick.Horizontal;
        _v = _joyStick.Vertical;
    }
    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(_h,_v).normalized * _moveSpeed;
    }
}
