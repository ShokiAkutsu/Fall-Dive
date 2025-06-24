using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdEndManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] CanvasGroup blackout;
	[SerializeField] Text edText;
	[SerializeField] GameObject buttonPanel_R;
	[SerializeField] GameObject buttonPanel_T;

	[Header("表示設定")]
	[SerializeField, TextArea] string swallowText = "あなたはつばめになりました。";
	[SerializeField, TextArea] string craneText = "あなたはつるになりました。";
	[SerializeField, TextArea] string blackKiteText = "あなたはとんびになりました。";
	[SerializeField, TextArea] string goalText = "あなたは無事、肉体に戻れました。";
	[SerializeField, TextArea] string groundText = "あなたは、地球と融合しました。";

	[SerializeField] float typeSpeed = 0.05f;

	bool isTyping = false;
	bool skipTyping = false;

	private void Start()
	{
		edText.text = "";
		buttonPanel_R.SetActive(false);
		buttonPanel_T.SetActive(false);
	}

	public void TriggerEnding(string kind)
	{
		Time.timeScale = 0f; // ゲーム停止
		string selectedText = "";

		switch (kind)
		{
			case "Swallow": selectedText = swallowText; break;
			case "Crane": selectedText = craneText; break;
			case "BlackKite": selectedText = blackKiteText; break;
			case "Goal": selectedText = goalText; break;
			case "Ground": selectedText = groundText; break;
			default: selectedText = "謎の存在に当たった…。"; break;
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
		buttonPanel_R.SetActive(true);
		buttonPanel_T.SetActive(true);
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
		SceneManager.LoadScene("TitleScene"); // ←タイトルシーン名に合わせて変更
	}
}
