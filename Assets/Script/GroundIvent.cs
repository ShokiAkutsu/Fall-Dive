using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundIvent : MonoBehaviour
{
	[SerializeField] BirdEndManager _birdEndManager;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
		{
			_birdEndManager.TriggerEnding("Ground");
		}
	}
}
