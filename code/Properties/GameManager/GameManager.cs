using Sandbox;

public sealed class GameManager : Component
{
	[Property] public BoardGoal lboard;
	[Property] public BoardGoal rboard;
	public int secondTimer = 60;
	public int minuteTimer = 1;

	protected override void OnUpdate()
	{
		if (secondTimer == 0)
		{
			minuteTimer--;
			secondTimer = 60;
		}
		if (secondTimer == 0 && minuteTimer == 0)
		{

		}
	}
}
