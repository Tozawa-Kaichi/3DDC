using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// シーンの遷移をステートパターンを用いて管理するシーンマネージャークラスです。
/// </summary>
public class StateSceneManager
{
    private SceneBase currentState;

    /// <summary>
    /// 初期シーン状態を設定します。
    /// </summary>
    public void SetInitialState(SceneBase initialState)
    {
        currentState = initialState;
        currentState.Enter();
    }

    /// <summary>
    /// トリガーに基づいて新しいシーンに遷移します。
    /// </summary>
    public void TransitionToScene(Trigger trigger)
    {
        SceneBase nextState = currentState.GetNextState(trigger);
        if (nextState != null)
        {
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }
    }
}
/// <summary>
/// シーン遷移のトリガーを表す列挙型です。
/// </summary>
public enum Trigger
{
    TitleRoad,
    MapUIRoad,
    BattleRoad
}