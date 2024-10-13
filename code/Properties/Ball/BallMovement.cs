using Microsoft.Win32;
using Sandbox;
using System.Diagnostics.Tracing;

public sealed class BallMovement : Component, Component.ICollisionListener, Component.ITriggerListener
{
	[Property] public Rigidbody rb;
	[Property] public SoundEvent sfx;
	public float speed = 170;
	public Vector2 direction;
	public float randomX;
	public float randomY;
	public bool entered = false;
	
	protected override void OnStart()
	{
		RandomDirection();
	}
	protected override void OnUpdate()
	{
		if (entered == true)
		{
			speed++;
		}
	}
	public void RandomDirection()
	{
		randomX = Game.Random.Int(-1,1);
		randomY = Game.Random.Int(-1, 1);
		
		if (randomX == 0)
		{
			randomX++;
		}
		if (randomY == 0)
		{
			randomY++;
		}
		direction = new Vector2(randomX, 0) + new Vector2(0, randomY);
		rb.Velocity = direction * speed;
	}
	public void OnCollisionStart(Collision other)
	{
		direction = Vector3.Reflect(direction, other.Contact.Normal).Normal.WithZ(0);
		other.Self.Body.Velocity = direction * speed;
		speed++;
		entered = true;
		Sound.Play(sfx);
	}
	public void OnCollisionStop(CollisionStop other)
	{
		entered = false;
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other != null)
		{
			WorldPosition = new Vector3 (0, 0, 0);
			RandomDirection();
		}
		speed = 150;
	}
}
