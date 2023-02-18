using Godot;
using System;

public class Player : KinematicBody2D
{
	struct input {
		public string right;
		public string left;
		public string jump;
	}
	
	[Export]
	private int playerID;
	[Export]
	public Color color;
	
	private input I;

	const int GRAVITY = 2000;
	const int SPEED = 600;
	const int JUMP_FORCE = 1200;	
	const float FRICTION = 0.1F;
	const float ACCELERATION = 0.25F;

	private Vector2 velocity = new Vector2(0,0);
	Area2D NearFloor;
	AnimationTree Animation;
	public override void _Ready(){
		I.right = "right" + playerID;
		I.left = "left" + playerID;
		I.jump = "jump" + playerID;

		NearFloor = this.GetNode<Area2D>("NearFloor");
		Animation = this.GetNode<AnimationTree>("AnimationTree");
		
		this.Modulate = color;
	}

	private void get_input(){
		Vector2 dir = new Vector2(Input.GetActionStrength(I.right) - Input.GetActionStrength(I.left), 0);
		dir.x += 0.9F;
		if (dir.x != 0){
			this.velocity.x = Mathf.Lerp(this.velocity.x, dir.x * SPEED, ACCELERATION);
		} else {
			this.velocity.x = Mathf.Lerp(this.velocity.x, 0, FRICTION);
		}
	}
	private void setAnimation(float v,bool nF){
		//Animation.Set("parameters/Blend2/blend_amount", 1-Math.Abs(v/600));
		if (nF){
			Animation.Set("parameters/RunAir/blend_position", -1.0);
			Animation.Set("parameters/TimeScale/scale", (v/300));
		} else {
			Animation.Set("parameters/RunAir/blend_position", 1.0);
			Animation.Set("parameters/TimeScale/scale", (v/400));
		}
	}
	private bool isNearFloor(){
		return (NearFloor.GetOverlappingBodies().Count != 0);
	}
	bool nearFloor = true;
	public override void _Process(float delta)
	{
		nearFloor = isNearFloor();

		get_input();
		
		this.velocity.y += GRAVITY * delta;

		if (nearFloor) {
			if (Input.IsActionJustPressed(I.jump)){
				velocity.y = -JUMP_FORCE;
			}
		}
		this.velocity = MoveAndSlide(this.velocity);

		setAnimation(this.velocity.x,nearFloor);
	}
}
