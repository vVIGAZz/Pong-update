using Sandbox;

public sealed class Ball : Component, Component.ICollisionListener
{
	[Property] public Rigidbody rb;
	[Property] public SoundEvent sfx;
	[Property] public float speed;
	public Vector2 direction;
    private float _timer;
    private bool _shouldRespawn = false;
    protected override void OnStart()
    {
		int num = Game.Random.Int(0, 2) == 1 ? 1 : -1;
		SetDirection(num);
		rb.Velocity = direction * speed;
    }
    protected override void OnFixedUpdate()
    {
        if (_shouldRespawn)
        {
            _timer -= Time.Delta;
            if (_timer <= 0)
            {
                _shouldRespawn = false;
                WorldPosition = 0;
                rb.Velocity = direction * speed;
            }
        }
    }
	public void SetDirection(int dir)
	{
		direction = new Vector3(dir, 0, 0);
	}
	public void OnCollisionStart(Collision other)
	{
		if (other.Other.GameObject.Tags.Has("paddle"))
		{
            var paddle = other.Other.GameObject.GetComponent<BoxCollider>();
            if (paddle != null)
            {
                var hitOffset = WorldPosition.y - other.Other.GameObject.WorldPosition.y;
                var halfHeight = paddle.Scale.y / 2;
                var normalize = hitOffset / (halfHeight);
                normalize = normalize.Clamp(-1f, 1f);
                float dir = direction.x > 0 ? -1 : 1;
                direction = new Vector3(dir, normalize, 0);
            }
        }
		else 
		{ 
			direction = Vector2.Reflect(direction, other.Contact.Normal).Normal;
        }
        rb.Velocity = direction * speed;
		speed++;
	}
    private void Respawn(int side)
    {
        if (side == 0)
        {
            SetDirection(-1);
        }
        if (side == 1)
        {
            SetDirection(1);
        }
        _timer = 0.7f;
        _shouldRespawn = true;
        speed = 180;
    }
    protected override void OnEnabled()
    {
        EventManager.GoalEvent += Respawn;
    }
    protected override void OnDisabled()
    {
        EventManager.GoalEvent -= Respawn;
    }
}
