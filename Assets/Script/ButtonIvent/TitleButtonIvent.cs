using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonIvent : MonoBehaviour
{
    public void OnClickButton()
    {
		Time.timeScale = 1f;
		SceneManager.LoadScene("TitleScene");
	}
}
