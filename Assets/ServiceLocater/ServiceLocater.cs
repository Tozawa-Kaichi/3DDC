using UnityEngine;
using System;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
public static class ServiceLocator
{
    // 登録されたサービスのインスタンスを保持するディクショナリ
    static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    /// <summary>
    /// サービスを登録するメソッド
    /// </summary>
    /// <typeparam name="T">キーとなるサービスの型</typeparam>
    /// <param name="service">格納するインスタンス</param>
    public static void RegisterService<T>(T service)
    {
        services[typeof(T)] = service;
    }
    /// <summary>
    /// 指定された型のサービスを取得するメソッド
    /// </summary>
    /// <typeparam name="T">指定された型</typeparam>
    /// <returns>指定されたサービスを返す</returns>
    public static T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }
        return default(T);
    }
}
