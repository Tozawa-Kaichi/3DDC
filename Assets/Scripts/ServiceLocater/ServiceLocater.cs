using UnityEngine;
using System;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
public static class ServiceLocator
{
    // �o�^���ꂽ�T�[�r�X�̃C���X�^���X��ێ�����f�B�N�V���i��
    static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    /// <summary>
    /// �T�[�r�X��o�^���郁�\�b�h
    /// </summary>
    /// <typeparam name="T">�L�[�ƂȂ�T�[�r�X�̌^</typeparam>
    /// <param name="service">�i�[����C���X�^���X</param>
    public static void RegisterService<T>(T service)
    {
        services[typeof(T)] = service;
    }
    /// <summary>
    /// �w�肳�ꂽ�^�̃T�[�r�X���擾���郁�\�b�h
    /// </summary>
    /// <typeparam name="T">�w�肳�ꂽ�^</typeparam>
    /// <returns>�w�肳�ꂽ�T�[�r�X��Ԃ�</returns>
    public static T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }
        return default(T);
    }
}
