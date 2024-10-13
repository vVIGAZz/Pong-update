using Sandbox;
using System.Reflection.Metadata;

public sealed class EnemyMove : Component
{
	[Property] public GameObject ball;
	[Property] public Rigidbody rb;
	public Vector2 direction;
	public float speed = 5f;

	protected override void OnUpdate()
	{
		if (ball.WorldPosition.y < WorldPosition.y)
		{
			direction = new Vector2(0, -20);
		}
		else if (ball.WorldPosition.y > WorldPosition.y)
		{
			direction = new Vector2(0, 20);
		}
		else
		{
			direction = new Vector2(0, 0);
		}
		rb.Velocity = direction * speed;
	}
}