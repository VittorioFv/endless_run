using Godot;
using System;

public class Camera : Camera2D
{
	KinematicBody2D player;
	public override void _Ready()
	{
		player = GetParent().GetNode<KinematicBody2D>("Player");
	}
	public override void _Process(float delta)
	{
		float pPos = player.Position.x;
		Position = new Vector2(pPos + 480, Position.y);
	}
}
