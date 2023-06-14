/// <summary>
/// シーンの基底クラスです。
/// </summary>
public abstract class SceneBase
{
    /// <summary>
    /// シーンに入る際の処理を定義します。
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// シーンから出る際の処理を定義します。
    /// </summary>
    public abstract void Exit();

    /// <summary>
    /// 次のシーンをトリガーに基づいて決定します。
    /// </summary>
    public abstract SceneBase GetNextState(Trigger trigger);
}