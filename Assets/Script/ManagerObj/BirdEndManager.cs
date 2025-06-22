using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdEndManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] CanvasGroup blackout;
	[SerializeField] Text edText;
	//[SerializeField] GameObject buttonPanel;

	[Header("�\���ݒ�")]
	[TextArea] public string swallowText = "���Ȃ��͂΂߂ɂȂ�܂����B";
	[TextArea] public string craneText = "���Ȃ��͂�ɂȂ�܂����B";
	[TextArea] public string blackKiteText = "���Ȃ��͂Ƃ�тɂȂ�܂����B";
	[TextArea] public string goalText = "���Ȃ��͖����A���̂ɖ߂�܂����B";

	[SerializeField] float typeSpeed = 0.05f;

	bool isTyping = false;
	bool skipTyping = false;

	public void TriggerEnding(string kind)
	{
		Time.timeScale = 0f; // �Q�[����~
		string selectedText = "";

		switch (kind)
		{
			case "Swallow": selectedText = swallowText; break;
			case "Crane": selectedText = craneText; break;
			case "BlackKite": selectedText = blackKiteText; break;
			case "Goal": selectedText = goalText; break;
			default: selectedText = "��̑��݂ɓ��������c�B"; break;
		}

		StartCoroutine(PlayEndingSequence(selectedText));
	}

	IEnumerator PlayEndingSequence(string fullText)
	{
		
		float t = 0f;
		while (t < 0.8f)
		{
			t += Time.unscaledDeltaTime;
			blackout.alpha = Mathf.Clamp01(t);
			yield return null;
		}

		isTyping = true;
		skipTyping = false;
		edText.text = "";

		for (int i = 0; i < fullText.Length; i++)
		{
			if (skipTyping)
			{
				edText.text = fullText;
				break;
			}

			edText.text += fullText[i];
			yield return new WaitForSecondsRealtime(typeSpeed);
		}

		isTyping = false;
		//buttonPanel.SetActive(true); 
	}

	void Update()
	{
		if (isTyping && Input.GetMouseButtonDown(0))
		{
			skipTyping = true;
		}
	}

	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ReturnToTitle()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("TitleScene"); // ���^�C�g���V�[�����ɍ��킹�ĕύX
	}
}
