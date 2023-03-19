using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ǂ��������玟�̖ړI�n�ւƐ؂�ւ��鏄��^
/// </summary>
public class PatrolEnemyMove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ���")] Transform[] _targets;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _stopDistance = 0.05f;//���B�����Ɣ��f���鋗��
    int _currentTargetIndex = 0;
    void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        float distance = Vector2.Distance(this.transform.position, _targets[_currentTargetIndex].position);

        if (distance > _stopDistance)
        {
            Vector3 dir = (_targets[_currentTargetIndex].transform.position - this.transform.position).normalized * _moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            _currentTargetIndex = (_currentTargetIndex + 1) % _targets.Length;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _currentTargetIndex = (_currentTargetIndex + 1) % _targets.Length;
    }
}
