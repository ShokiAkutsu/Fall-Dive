using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
    AltitudeManager _AltitudeManager;

    [Header("ƒJƒƒ‰‚ªˆÚ“®‚·‚é•W‚")]
    [SerializeField] int _moveAltitude = 1000;

	float timer = 0f;
	float duration = 1f;
	float startSize = 5f;
	float endSize = 10f;

	bool _isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        _AltitudeManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AltitudeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_AltitudeManager.Remaining < _moveAltitude)
        {
            _isMove = true;
		}
	}

	void LateUpdate()
	{
        if(_isMove)
        {
			timer += Time.deltaTime;
			float t = Mathf.Clamp01(timer / duration);
			Camera.main.orthographicSize = Mathf.Lerp(startSize, endSize, t);
		}
	}
}
