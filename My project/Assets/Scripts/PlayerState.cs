using UnityEngine;

public class PlayerState
{
    public Player player;
    public PlayerStateMashine statemashine;

    public string aniboolname;

    public float xInput;

    public PlayerState(Player _player, PlayerStateMashine _statemashine, string _aniboolname)
    {
        this.player = _player;
        this.statemashine = _statemashine;
        this.aniboolname = _aniboolname;
    }

    public virtual void Enter()
    {
        player.ani.SetBool(aniboolname, true);
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit()
    {
        player.ani.SetBool(aniboolname, false);
    }

}
