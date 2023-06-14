using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : SceneBase
{
    public override void Enter()
    {
        // バトルシーンに入る際の処理
    }

    public override void Exit()
    {
        // バトルシーンから出る際の処理
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
