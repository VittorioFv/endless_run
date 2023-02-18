using Godot;
using System;

public class Gameplay : Node2D
{
	
	public override void _Ready()
	{
		GD.Randomize();
		
		PackedScene blocco = (PackedScene)ResourceLoader.Load("res://scene/Blocco.tscn");
		
		for(int i = 0; i<200; i++){
			StaticBody2D newBlocco = (StaticBody2D)blocco.Instance();
			newBlocco.Call("setScale", GD.Randi() % 8);
			newBlocco.Position = new Vector2(i*300, GD.Randi()%700 + 200);
			
			AddChild(newBlocco);
		}
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		Node b = (Node)body;
		GD.Print(b);
		b.Free();
	}
}



