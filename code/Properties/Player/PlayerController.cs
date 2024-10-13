using Sandbox;

public sealed class PlayerController : Component
{
	[Property] public Rigidbody body;

	private float speed = 5f;
	protected override void OnUpdate()
	{
		if (Input.Down("Backward")) 
		{
			body.Velocity += Vector3.Right * speed;
		}
		else if (Input.Down("Forward")) 
		{
			body.Velocity += Vector3.Left * speed;
		}
	}
}
