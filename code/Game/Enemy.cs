using Sandbox;

public sealed class Enemy : Component
{
    [Property] public GameObject ball;
    [Property] public Rigidbody rb;
    [Property] public float speed;
    [Property] public Vector3 wishVelocity;
    protected override void OnFixedUpdate()
	{

        if (ball.WorldPosition.y < WorldPosition.y) wishVelocity -= 1;
        if (ball. WorldPosition.y > WorldPosition.y) wishVelocity += 1;
        //else wishVelocity = 0;
        rb.SmoothMove(wishVelocity, 0.2f, Time.Delta / speed);
	}
}
