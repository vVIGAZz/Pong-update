using Sandbox;

public sealed class BoardGoal : Component, Component.ITriggerListener
{
	[Property] public GameObject ball;
	[Property] public bool sideBoard = false;
	public int playerOne = 0;
	public int playerTwo = 0;

	public void OnTriggerEnter(Collider other)
	{
		if (sideBoard == false && other != null)
		{
			playerOne++;
		}
		if (sideBoard == true && other != null)
		{
			playerTwo++;
		}
	}
}
