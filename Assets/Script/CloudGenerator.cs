using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	[Header("CloudPrefab���i�[")]
	[SerializeField] GameObject _cloud;
	[Header("Prefab�����p�x")]
	[SerializeField] float _interval = 3f;
	[Header("Prefab�̔����͈�(�}X���W ��Βl)")]
	[SerializeField] float _posLimitX = 10f;
	[Header("�������Ȃ��W��")]
	[SerializeField] float _roundUpAltitude = 500f;

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

			if (_timer > _interval)
			{
				_timer = 0;
				GameObject Cloud = Instantiate(_cloud);
				float posX = Random.Range(-(_posLimitX), _posLimitX);
				Cloud.transform.position = new Vector3(posX, transform.position.y, 0);
			}
			
			//���߂�ꂽ�W������_�𐶐����Ȃ��悤�ɂ���
			if(_altitudeManager.Remaining < _roundUpAltitude)
			{
				_isCreate = false;
			}
		}
	}
}
