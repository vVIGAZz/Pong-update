using Sandbox;

public sealed class Goal : Component, Component.ITriggerListener
{
	[Property] public int Side;
	public void OnTriggerEnter(Collider other)
	{
		if (other.Tags.Has("ball"))
		{
			EventManager.OnGoal(Side);
		}
	}
}
