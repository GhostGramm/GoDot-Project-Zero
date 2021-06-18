using Godot;
using System;

public class Enemy : StaticBody2D
{
    Vector2 direction = new Vector2();
    public Player player;

    public int BulletfrmEnemy = 20;
    public override void _Ready()
    {
        Timer timer = GetNode<Timer>("Timer");
        timer.WaitTime = 0.7f;
        timer.Connect("timeout",this,"SpawnBullet");
        timer.Start();
    }

    public override void _PhysicsProcess(float delta)
    {
        EnemyBullet.direction = direction;
    }

//  // Called every frae. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public void SpawnBullet()
    {
        var enemyBullet = GD.Load<PackedScene>("res://Scenes/EnemyBullet.tscn");
        direction = (Player.pstion - this.Position).Normalized();
        
        GD.Print("Enemy Bullet");
        Area2D b = (Area2D)enemyBullet.Instance();
        this.GetParent().AddChild(b);
        b.Position = this.Position + direction * BulletfrmEnemy;
    }
}
