using Sandbox;

public sealed class Player : Component
{
	[Property] public Rigidbody rb;
	[Property] public float speed;
	[Property] public Vector3 wishVelocity;
	protected override void OnFixedUpdate()
	{
		wishVelocity = 0;
		if (Input.Down("forward")) wishVelocity.y += 1;
		if (Input.Down("backward")) wishVelocity.y -= 1;
		rb.Velocity = wishVelocity * speed;
	}
}
