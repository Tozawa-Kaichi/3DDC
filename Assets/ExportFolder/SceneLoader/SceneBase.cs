/// <summary>
/// �V�[���̊��N���X�ł��B
/// </summary>
public abstract class SceneBase
{
    /// <summary>
    /// �V�[���ɓ���ۂ̏������`���܂��B
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// �V�[������o��ۂ̏������`���܂��B
    /// </summary>
    public abstract void Exit();

    /// <summary>
    /// ���̃V�[�����g���K�[�Ɋ�Â��Č��肵�܂��B
    /// </summary>
    public abstract SceneBase GetNextState(Trigger trigger);
}