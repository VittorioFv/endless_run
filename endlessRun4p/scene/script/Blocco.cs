using Godot;
using System;

public class Blocco : StaticBody2D
{
	[Obsolete]
	public void setScale(int s){
		GetNode<CollisionShape2D>("CollisionShape2D").Scale = new Vector2(s, 0);
		GetNode<Line2D>("Line2D").SetPoints(new Vector2[]{new Vector2(13 * (3 + 4 * (s - 1)), 0), new Vector2(-13 * (3 + 4 * (s - 1)), 0)});
		
		GD.Print(GetNode<Line2D>("Line2D").Points[0]);
		
		
		GetNode<KinematicBody2D>("Player1");
	}
}
