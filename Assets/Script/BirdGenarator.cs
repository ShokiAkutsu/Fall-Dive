using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenarator : MonoBehaviour
{
	[Header("BirdPrefabを格納")]
	[SerializeField] GameObject[] _bird;
	[Header("Prefab生成頻度")]
	[SerializeField] float _interval = 5f;
	[Header("Prefabの発生範囲(±X座標 絶対値)")]
	[SerializeField] float _posLimitX = 5f;
	[Header("生成しない標高")]
	[SerializeField] float _roundUpAltitude = 1500f;

	AltitudeManager _altitudeManager;   //標高の取得

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

			//決められた標高から鳥を生成しないようにする
			if (_altitudeManager.Remaining < _roundUpAltitude)
			{
				_isCreate = false;
			}

			else if (_timer > _interval)
			{
				//鳥の作成頻度を不規則にする
				_timer = Random.Range(0f, _interval);

				int index = Random.Range(0, _bird.Length);
				GameObject Bird = Instantiate(_bird[index]);
				float posX = Random.Range(-(_posLimitX), _posLimitX);
				Bird.transform.position = new Vector3(posX, transform.position.y, 0);
			}
		}
	}
}
