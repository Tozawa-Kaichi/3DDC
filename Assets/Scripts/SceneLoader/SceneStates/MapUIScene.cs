using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIScene : SceneBase
{
    public override void Enter()
    {
        // �}�b�vUI�V�[���ɓ���ۂ̏���
    }

    public override void Exit()
    {
        // �}�b�vUI�V�[������o��ۂ̏���
    }

    public override SceneBase GetNextState(Trigger trigger)
    {
        switch (trigger)
        {
            case Trigger.TitleRoad:
                return new TitleScene();
            case Trigger.BattleRoad:
                return new BattleScene();
            default:
                return null;
        }
    }
}

