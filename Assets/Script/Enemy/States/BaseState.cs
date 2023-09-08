public abstract class BaseState
{
    public EnemyClass enemy;
    public StateMachine stateMachine;
    public abstract void Enter();

    public abstract void Perform();

    public abstract void Exit();

} 