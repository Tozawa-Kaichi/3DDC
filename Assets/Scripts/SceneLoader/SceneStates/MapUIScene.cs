using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIScene : SceneBase
{
    public override void Enter()
    {
        // マップUIシーンに入る際の処理
    }

    public override void Exit()
    {
        // マップUIシーンから出る際の処理
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

