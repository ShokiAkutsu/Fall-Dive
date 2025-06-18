using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeManager : MonoBehaviour
{
    GameTimeManager _gameTimeManager;

	[Header("�\������ŏ��̍���")]
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
		//���̕W�����c�莞�Ԃ��擾���ĐρB�����ŏo��
		float ratio = _gameTimeManager.GetRatioTime();
		_remaining = (int)(_altitude * ratio);
	}
}
