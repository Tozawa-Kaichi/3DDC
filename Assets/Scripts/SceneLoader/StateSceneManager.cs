using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// �V�[���̑J�ڂ��X�e�[�g�p�^�[����p���ĊǗ�����V�[���}�l�[�W���[�N���X�ł��B
/// </summary>
public class StateSceneManager
{
    private SceneBase currentState;

    /// <summary>
    /// �����V�[����Ԃ�ݒ肵�܂��B
    /// </summary>
    public void SetInitialState(SceneBase initialState)
    {
        currentState = initialState;
        currentState.Enter();
    }

    /// <summary>
    /// �g���K�[�Ɋ�Â��ĐV�����V�[���ɑJ�ڂ��܂��B
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
/// �V�[���J�ڂ̃g���K�[��\���񋓌^�ł��B
/// </summary>
public enum Trigger
{
    TitleRoad,
    MapUIRoad,
    BattleRoad
}