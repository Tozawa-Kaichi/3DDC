using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase
{
    public override void Enter()
    {
        // �^�C�g���V�[���ɓ���ۂ̏���
    }

    public override void Exit()
    {
        // �^�C�g���V�[������o��ۂ̏���
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
