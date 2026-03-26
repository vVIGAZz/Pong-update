using Sandbox;

public sealed class GameManager : Component
{
	private bool _isPause;

	protected override void OnAwake()
	{
		GameObject.Flags = GameObjectFlags.DontDestroyOnLoad;
	}

	protected override void OnUpdate()
	{
		if (Input.EscapePressed)
		{
			//Input.EscapePressed = false;
			_isPause = !_isPause;
		}
		Scene.TimeScale = _isPause ? 0f : 1f;
	}
	
}
