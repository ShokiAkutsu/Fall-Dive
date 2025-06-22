using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenarator : MonoBehaviour
{
	[Header("BirdPrefab���i�[")]
	[SerializeField] GameObject[] _bird;
	[Header("Prefab�����p�x")]
	[SerializeField] float _interval = 5f;
	[Header("Prefab�̔����͈�(�}X���W ��Βl)")]
	[SerializeField] float _posLimitX = 5f;
	[Header("�������Ȃ��W��")]
	[SerializeField] float _roundUpAltitude = 1500f;

	AltitudeManager _altitudeManager;   //�W���̎擾

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

			//���߂�ꂽ�W�����璹�𐶐����Ȃ��悤�ɂ���
			if (_altitudeManager.Remaining < _roundUpAltitude)
			{
				_isCreate = false;
			}

			else if (_timer > _interval)
			{
				//���̍쐬�p�x��s�K���ɂ���
				_timer = Random.Range(0f, _interval);

				int index = Random.Range(0, _bird.Length);
				GameObject Bird = Instantiate(_bird[index]);
				float posX = Random.Range(-(_posLimitX), _posLimitX);
				Bird.transform.position = new Vector3(posX, transform.position.y, 0);
			}
		}
	}
}
