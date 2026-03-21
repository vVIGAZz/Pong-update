using Sandbox;
using System;

public sealed class EventManager : Component
{
	public static Action<int> GoalEvent;
	
	public static void OnGoal(int side)
	{
		GoalEvent?.Invoke(side);
	}
}
