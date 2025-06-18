using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	[Header("CloudPrefab‚ğŠi”[")]
	[SerializeField] GameObject _cloud;
	[Header("Prefab¶¬•p“x")]
	[SerializeField] float _interval = 3f;
	[Header("Prefab‚Ì”­¶”ÍˆÍ(}XÀ•W â‘Î’l)")]
	[SerializeField] float _posLimitX = 10f;
	[Header("¶¬‚µ‚È‚¢•W‚")]
	[SerializeField] float _roundUpAltitude = 500f;

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

			if (_timer > _interval)
			{
				_timer = 0;
				GameObject Cloud = Instantiate(_cloud);
				float posX = Random.Range(-(_posLimitX), _posLimitX);
				Cloud.transform.position = new Vector3(posX, transform.position.y, 0);
			}
			
			//Œˆ‚ß‚ç‚ê‚½•W‚‚©‚ç‰_‚ğ¶¬‚µ‚È‚¢‚æ‚¤‚É‚·‚é
			if(_altitudeManager.Remaining < _roundUpAltitude)
			{
				_isCreate = false;
			}
		}
	}
}
