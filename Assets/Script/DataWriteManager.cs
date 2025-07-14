using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataWriteManager : MonoBehaviour
{
    BitEndFlag _bitEndFlag;

    private void Start()
    {
		_bitEndFlag = (BitEndFlag)PlayerPrefs.GetInt("Comp");
	}

	public void WriteFlag(int flag)
    {
        BitEndFlag bitFlag = (BitEndFlag)flag;

        //ƒtƒ‰ƒO‚ÌŠi”[
        _bitEndFlag |= bitFlag;

        int FlagNum = (int)_bitEndFlag;

		PlayerPrefs.SetInt("Comp", FlagNum);
	}
}

[Flags]
enum BitEndFlag
{
    Kite = 0x001,
    Crane = 0x002,
    Swallow = 0x004,
    Girl = 0x008,
    Ground = 0x010,
}
