using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : SceneBase
{
    public override void Enter()
    {
        // �o�g���V�[���ɓ���ۂ̏���
    }

    public override void Exit()
    {
        // �o�g���V�[������o��ۂ̏���
    }

    public override SceneBase GetNextState(Trigger trigger)
    {
        switch (trigger)
        {
            case Trigger.MapUIRoad:
                return new MapUIScene();
            default:
                return null;
        }
    }
}
