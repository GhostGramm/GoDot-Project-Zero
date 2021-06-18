using Godot;
using System;

public class Bullet : Area2D
{
    public static Vector2 dir = new Vector2();
    public const int SPEED = 300;
    public Bullet bullet;
    
    public override void _Ready()
    {
        Area2D area = GetNode<Area2D>(".");
        area.Connect("body_entered",this,"DestroyEnemy");

        Timer timer  = GetNode<Timer>("Timer");
        timer.WaitTime = 0.7f;
        timer.Connect("timeout",this,"DestroyBullet");
        timer.Start();

        
    }

    public override void _PhysicsProcess(float delta){

        this.Translate(dir * SPEED * delta);
        
        
    }

    public void DestroyEnemy(Node body){
        GD.Print("test working");
        if(body.IsInGroup("Enemy")){
            body.QueueFree();
            DestroyBullet();
        }
        else if (body.IsInGroup("Obstacle"))
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet(){
        this.QueueFree();
    }

    

    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
