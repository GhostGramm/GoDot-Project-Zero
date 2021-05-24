using Godot;
using System;

public class Player : KinematicBody2D
{
    
    public override void _Ready()
    {
        //getting the child of the node
        Sprite sprite = GetNode<Sprite>("art");
        sprite.RotationDegrees = 90;  //rotating the child 90*
    }

    public override void _PhysicsProcess(float delta)
    {
        var bullet = GD.Load<PackedScene>("res://Scenes/Bullet.tscn"); // calling the bullet scene
        var speed = 50;
        var BulletDisFromPlayer = 20;
        var direction = (GetGlobalMousePosition() - this.Position).Normalized();

        this.Rotation = direction.Angle();

        if(Input.IsActionPressed("ui_up")){
            // this.Translate(new Vector2(0,-1));
            this.MoveAndSlide(direction * speed);
            GD.Print(this.Position);
        }

        if(Input.IsActionJustReleased("i_shoot")){
            GD.Print("shooting");
            Area2D b = (Area2D)bullet.Instance(); // calling
            this.GetParent().AddChild(b); //adding the bullet as a child of World
            b.Position = this.Position + direction * BulletDisFromPlayer;
            Bullet.dir = direction;
            b.Rotation = direction.Angle();
        }
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
