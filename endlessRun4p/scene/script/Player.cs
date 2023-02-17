using Godot;
using System;

public class Player : KinematicBody2D
{
	const int GRAVITY = 2000;
	const int SPEED = 600;
	const int JUMP_FORCE = 1200;	
	const float FRICTION = 0.1F;
	const float ACCELERATION = 0.25F;

	static Vector2 velocity = new Vector2(0,0);
	Area2D NearFloor;
	AnimationTree Animation;
	public override void _Ready(){
		NearFloor = this.GetNode<Area2D>("NearFloor");
		Animation = this.GetNode<AnimationTree>("AnimationTree");
	}

	public static void get_input(){
		Vector2 dir = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"), 0);
		dir.x += 0.8F;
		if (dir.x != 0){
			velocity.x = Mathf.Lerp(velocity.x, dir.x * SPEED, ACCELERATION);
		} else {
			velocity.x = Mathf.Lerp(velocity.x, 0, FRICTION);
		}
	}
	private void setAnimation(float v,bool nF){
		Animation.Set("parameters/Blend2/blend_amount", 1-Math.Abs(v/600));
		Animation.Set("parameters/TimeScale/scale", (v/300));
	}
	private bool isNearFloor(){
		return (NearFloor.GetOverlappingBodies().Count != 0);
	}
	bool nearFloor = true;
	public override void _Process(float delta)
	{
		nearFloor = isNearFloor();

		get_input();
		
		velocity.y += GRAVITY * delta;

		if (nearFloor) {
			if (Input.IsActionJustPressed("jump")){
				velocity.y = -JUMP_FORCE;
				GD.Print("salta");
			}
		}
		velocity = MoveAndSlide(velocity);

		setAnimation(velocity.x,nearFloor);
	}
}
