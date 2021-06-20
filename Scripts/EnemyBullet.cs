using Godot;
using System;

public class EnemyBullet : Area2D
{
    public static Vector2 direction = new Vector2();
    public const int Speed = 100;
    public override void _Ready()
    {
        Area2D area = GetNode<Area2D>(".");
        area.Connect("body_entered",this,"DestroyPlayer");

        Timer timer = GetNode<Timer>("Timer");
        timer.WaitTime = 5f;
        timer.Connect("timeout",this,"DestroyBullet");
        timer.Start();
    }

    public override void _PhysicsProcess(float delta)
    {
        this.Translate(direction * Speed * delta);
    }

    public void DestroyBullet()
    {
        this.QueueFree();
    }

    public void DestroyPlayer(Node body)
    {
        if(body.IsInGroup("Player"))
        {
            body.QueueFree();
            GetTree().ReloadCurrentScene();
        }
        else if(body.IsInGroup("Obstacle"))
        {
            DestroyBullet();
        }
        else if(body.IsInGroup("Enemy"))
        {
            DestroyBullet();
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
