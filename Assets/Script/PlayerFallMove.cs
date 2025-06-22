using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerFallMove : MonoBehaviour
{
	[Header("目標とする座標")]
	[SerializeField] Transform _goal;
	[Header("落下にかける秒数")]
	[SerializeField] float fallDuration = 8f;
	[Header("降下する高さ")]
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
		// 初期位置セット
		startY = transform.position.y;
		// 最終位置セット
		endY = _goal.position.y;

		GameObject managerObj = GameObject.Find("Manager");

		if (managerObj == null)
		{
			Debug.LogError("Manager オブジェクトが見つかりません！");
			return;
		}

		_altitudeManager = managerObj.GetComponent<AltitudeManager>();
		if (_altitudeManager == null)
		{
			Debug.LogError("AltitudeManager が Manager にありません！");
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

			// Y座標をLerpで自動的に落とす
			float newY = Mathf.Lerp(startY, endY, t);

			// 現在のXを維持しながらYだけ更新
			Vector2 newVelocity = _rb.velocity;
			newVelocity.y = (newY - transform.position.y) / Time.fixedDeltaTime;
			_rb.velocity = newVelocity;
		}
	}
}
