using Sandbox;

public sealed class Enemy : Component
{
    [Property] public GameObject ball;
    [Property] public Rigidbody rb;
    [Property] public float speed;
    [Property] public Vector3 wishVelocity;
    protected override void OnFixedUpdate()
	{

        if (ball.WorldPosition.y < WorldPosition.y) wishVelocity -= 2;
        if (ball. WorldPosition.y > WorldPosition.y) wishVelocity += 2;
        //else wishVelocity = 0;
        rb.SmoothMove(wishVelocity, 0.7f, Time.Delta);
	}
}
