using Sandbox;

public sealed class Ball : Component, Component.ICollisionListener
{
	[Property] public Rigidbody rb;
	[Property] public SoundEvent sfx;
	[Property] public float speed;
	public Vector2 direction;
    protected override void OnStart()
    {
		int num = Game.Random.Int(0, 2) == 1 ? 1 : -1;
		SetDirection(num);
		rb.Velocity = direction * speed;
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
}
