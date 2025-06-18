using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeManager : MonoBehaviour
{
    GameTimeManager _gameTimeManager;

	[Header("表示する最初の高さ")]
	[SerializeField] float _altitude = 10000f;

	int _remaining;
	public int Remaining => _remaining;

	// Start is called before the first frame update
	void Start()
	{
		_gameTimeManager = GameObject.Find("Manager").GetComponent<GameTimeManager>();
	}

	// Update is called once per frame
	void Update()
	{
		//今の標高を残り時間を取得して積。割合で出す
		float ratio = _gameTimeManager.GetRatioTime();
		_remaining = (int)(_altitude * ratio);
	}
}
