using Godot;
using System;

public class Camera : Camera2D
{
	KinematicBody2D[] players;
	public override void _Ready()
	{
		players = new KinematicBody2D[] {GetParent().GetNode<KinematicBody2D>("Player1"),
										GetParent().GetNode<KinematicBody2D>("Player2"),
										GetParent().GetNode<KinematicBody2D>("Player3"),
										GetParent().GetNode<KinematicBody2D>("Player4")};
		if(players[3] == null){
			int index = 3;
			
			for (int i = index; i < players.Length - 1; i++)    {
				players[i] = players[i + 1];
			}
			Array.Resize(ref players, players.Length - 1);
		}
		if(players[2] == null){
			int index = 2;
			
			for (int i = index; i < players.Length - 1; i++)    {
				players[i] = players[i + 1];
			}
			Array.Resize(ref players, players.Length - 1);
		}
		if(players[1] == null){
			int index = 1;
			
			for (int i = index; i < players.Length - 1; i++)    {
				players[i] = players[i + 1];
			}
			Array.Resize(ref players, players.Length - 1);
		}
		
		GD.Print(players.Length);
	}
	public override void _Process(float delta)
	{
		float pPos = players[0].Position.x;
		for (int i = 1; i < players.Length; i++){
			pPos += players[i].Position.x;
		}
		pPos = pPos/players.Length;
		Position = new Vector2(pPos + 480, Position.y);
	}
}
