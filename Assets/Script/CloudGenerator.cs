using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	[Header("CloudPrefabを格納")]
	[SerializeField] GameObject _cloud;
	[Header("Prefab生成頻度")]
	[SerializeField] float _interval = 3f;
	[Header("Prefabの発生範囲(±X座標 絶対値)")]
	[SerializeField] float _posLimitX = 10f;
	[Header("生成しない標高")]
	[SerializeField] float _roundUpAltitude = 500f;

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

			if (_timer > _interval)
			{
				_timer = 0;
				GameObject Cloud = Instantiate(_cloud);
				float posX = Random.Range(-(_posLimitX), _posLimitX);
				Cloud.transform.position = new Vector3(posX, transform.position.y, 0);
			}

			//決められた標高から雲を生成しないようにする
			if (_altitudeManager.Remaining < _roundUpAltitude)
			{
				_isCreate = false;
			}
		}
	}
}
