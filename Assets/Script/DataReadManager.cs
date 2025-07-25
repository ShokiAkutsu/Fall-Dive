using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataReadManager : MonoBehaviour
{
	[SerializeField] Text m_messageText = default;

	void Start()
	{
		if (m_messageText)
		{
			int endCollectFlag = PlayerPrefs.GetInt("Comp");
			int count = 0;

			//フラグの立っている数を判定
			while(endCollectFlag != 0)
			{
				count++;
				endCollectFlag &= (endCollectFlag - 1);
			}

			m_messageText.text = $"END 回収率：{count} / 5";
		}
	}
}
