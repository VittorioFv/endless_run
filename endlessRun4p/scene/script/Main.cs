using Godot;
using System;

public class Main : Node2D
{
	public void play(){
		PackedScene gp = (PackedScene)ResourceLoader.Load("res://scene/Gameplay.tscn");
		Node2D newGP = (Node2D)gp.Instance();
		
		
		Node2D chooseMenu = GetChild<Node2D>(0);
		
		for(int i = 0; i <4; i++) {
			if  (!(bool)chooseMenu.Call("getP", i)) {
				newGP.GetNode<KinematicBody2D>("Player"+(i+1)).Free();
			}
		}
		
		AddChild(newGP);
		
		GetChild(0).Free();
	}
}
