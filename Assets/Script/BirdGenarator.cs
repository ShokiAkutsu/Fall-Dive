using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenarator : MonoBehaviour
{
	[Header("BirdPrefab‚ğŠi”[")]
	[SerializeField] GameObject[] _bird;
	[Header("Prefab¶¬•p“x")]
	[SerializeField] float _interval = 5f;
	[Header("Prefab‚Ì”­¶”ÍˆÍ(}XÀ•W â‘Î’l)")]
	[SerializeField] float _posLimitX = 5f;
	[Header("¶¬‚µ‚È‚¢•W‚")]
	[SerializeField] float _roundUpAltitude = 1500f;

	AltitudeManager _altitudeManager;   //•W‚‚Ìæ“¾

	float _timer;
	bool _isCreate = true;

	// Start is called before the first frame update
	void Start()
	{
		_altitudeManager = GameObject.Find("Manager").GetComponent<AltitudeManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (_isCreate)
		{
			_timer += Time.deltaTime;

			//Œˆ‚ß‚ç‚ê‚½•W‚‚©‚ç’¹‚ğ¶¬‚µ‚È‚¢‚æ‚¤‚É‚·‚é
			if (_altitudeManager.Remaining < _roundUpAltitude)
			{
				_isCreate = false;
			}

			else if (_timer > _interval)
			{
				//’¹‚Ìì¬•p“x‚ğ•s‹K‘¥‚É‚·‚é
				_timer = Random.Range(0f, _interval);

				int index = Random.Range(0, _bird.Length);
				GameObject Bird = Instantiate(_bird[index]);
				float posX = Random.Range(-(_posLimitX), _posLimitX);
				Bird.transform.position = new Vector3(posX, transform.position.y, 0);
			}
		}
	}
}
