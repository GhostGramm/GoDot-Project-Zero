using Godot;
using System;

public class Enemy : StaticBody2D
{
    Vector2 direction = new Vector2();
    public Player player;

    public int BulletfrmEnemy = 30;
    public override void _Ready()
    {
        direction = GetDirection(0);

        Timer timer = GetNode<Timer>("Timer");
        timer.WaitTime = 0.7f;
        timer.Connect("timeout",this,"SpawnBullet");
        timer.Start();
    }

    public override void _PhysicsProcess(float delta)
    {
        direction = GetDirection(0);
        
    }

//  // Called every frae. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public void SpawnBullet()
    {
        var enemyBullet = GD.Load<PackedScene>("res://Scenes/EnemyBullet.tscn");
        direction = GetDirection(50);
        
        GD.Print("Enemy Bullet");
        Area2D b = (Area2D)enemyBullet.Instance();
        this.GetParent().AddChild(b);
        b.Position = this.Position + direction * BulletfrmEnemy;
        EnemyBullet.direction = direction;
    }

    public Vector2 GetDirection(int Offset)
    {
        Vector2 newDirection = (Player.pstion - this.Position);
        double RandomOffset = GD.RandRange(-Offset,Offset);
        newDirection = new Vector2(newDirection.x + (float)RandomOffset, newDirection.y + (float)RandomOffset);
        return newDirection.Normalized();
    }

}
