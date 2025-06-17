using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	[Header("CloudPrefab‚ðŠi”[")]
	[SerializeField] GameObject _cloud;
	[Header("Prefab¶¬•p“x")]
	[SerializeField] float _interval = 3f;
	[Header("Prefab‚Ì”­¶”ÍˆÍ(}XÀ•W â‘Î’l)")]
	[SerializeField] float _posLimitX = 10f;

	float _timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		_timer += Time.deltaTime;

		if (_timer > _interval)
		{
			_timer = 0;
			GameObject Cloud = Instantiate(_cloud);
			float posX = Random.Range(-(_posLimitX), _posLimitX);
			Cloud.transform.position = new Vector3(posX, -6, 0);
		}
	}
}
