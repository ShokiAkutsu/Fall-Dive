using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerFallMove : MonoBehaviour
{
	[Header("�ڕW�Ƃ�����W")]
	[SerializeField] Transform _goal;
	[Header("�����ɂ�����b��")]
	[SerializeField] float fallDuration = 8f;
	[Header("�~�����鍂��")]
	[SerializeField] int _fallAltitude = 1200;

	float startY;
	float endY;

	Rigidbody2D _rb;
	float _timer = 0f;

	AltitudeManager _altitudeManager;
	bool _isFall = false;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		// �����ʒu�Z�b�g
		startY = transform.position.y;
		// �ŏI�ʒu�Z�b�g
		endY = _goal.position.y;

		GameObject managerObj = GameObject.Find("Manager");

		if (managerObj == null)
		{
			Debug.LogError("Manager �I�u�W�F�N�g��������܂���I");
			return;
		}

		_altitudeManager = managerObj.GetComponent<AltitudeManager>();
		if (_altitudeManager == null)
		{
			Debug.LogError("AltitudeManager �� Manager �ɂ���܂���I");
		}
	}

	private void Update()
	{
		if (!_isFall && _fallAltitude > _altitudeManager.Remaining)
		{
			_isFall = true;
		}
	}

	void FixedUpdate()
	{
		if(_isFall)
		{
			_timer += Time.fixedDeltaTime;
			float t = Mathf.Clamp01(_timer / fallDuration);

			// Y���W��Lerp�Ŏ����I�ɗ��Ƃ�
			float newY = Mathf.Lerp(startY, endY, t);

			// ���݂�X���ێ����Ȃ���Y�����X�V
			Vector2 newVelocity = _rb.velocity;
			newVelocity.y = (newY - transform.position.y) / Time.fixedDeltaTime;
			_rb.velocity = newVelocity;
		}
	}
}
