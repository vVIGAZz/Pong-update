using Sandbox;

public sealed class Enemy : Component
{
    [Property] public GameObject ball;
    [Property] public Rigidbody rb;
    [Property] public float speed;
    [Property] public Vector3 wishVelocity;
    private float _reaction = 0.15f;
    private float _deadzone;
    private float _target;
    protected override void OnFixedUpdate()
	{
        _reaction -= Time.Delta;
        if (_reaction <= 0f)
        {
            _target = ball.WorldPosition.y;
        }
        if (_target < WorldPosition.y) wishVelocity -= 1;
        if (_target > WorldPosition.y) wishVelocity += 1;
        rb.Velocity = wishVelocity * speed;
	}
}
