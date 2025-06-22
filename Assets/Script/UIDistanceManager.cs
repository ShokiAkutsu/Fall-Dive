using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class UIDistanceManager : MonoBehaviour
{
	Text _altitudeText;                 //Œ»İ‚Ì•W‚‚ğ•\¦‚·‚é
	AltitudeManager _altitudeManager;   //•W‚‚Ìæ“¾

	// Start is called before the first frame update
	void Start()
    {
        _altitudeText = GameObject.Find("DistanceText").GetComponent<Text>();
        _altitudeManager = GameObject.Find("Manager").GetComponent<AltitudeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = _altitudeManager.Remaining;
		_altitudeText.text = distance.ToString() + " m ";
    }
}
