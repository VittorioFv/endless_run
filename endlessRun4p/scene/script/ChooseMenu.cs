using Godot;
using System;

public class ChooseMenu : Node2D
{
	public bool[] p;
	private bool[] ready;
	
	public override void _Ready()
	{
		p = new bool[] {true, false, false, false};
		ready = new bool[] {false, true, true, true};
	}
	
	private bool get_input(){
		for(int i = 0; i <4; i++) {
			if (this.p[i]) {
				if (Input.IsActionJustPressed("jump"+(i+1))){
					ready[i] = true;
					GetNode("Player"+(i+1)).GetNode<Label>("Label").Visible = true;
				}
			}
		}
		
		for(int i = 1; i <4; i++) {
			if  (!this.p[i]) {
				if (Input.IsActionJustPressed("jump"+(i+1))){
					this.p[i] = true;
					ready[i] = false;
					
					GetNode<KinematicBody2D>("Player"+(i+1)).Visible = true;
				}
			}
		}
		
		return (ready[0] && ready[1] && ready[2] && ready[3]);
	}
	
	public bool getP(int i){
		return this.p[i];
	}

	public override void _Process(float delta)
	{
		if ( get_input() ){
			Node2D n = this.GetParent<Node2D>();
			n.Call("play");
		}
	}
}
