using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMashine mashine;

    protected string animboolName;


    public PlayerState (Player _player, PlayerStateMashine _mashine, string animboolName)
    {
        this.player = _player;
        this.mashine = _mashine;
        this.animboolName = animboolName;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
