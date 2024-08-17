using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class StartBtn : MonoBehaviour
{
    public Image fadeImage;  // 페이드 효과를 위한 이미지
    public Button startButton;  // Start 버튼
    public float fadeDuration = 2.0f;  // 페이드 시간
    private CanvasGroup buttonCanvasGroup;  // 버튼의 CanvasGroup
    private void Start() {
        buttonCanvasGroup = startButton.GetComponent<CanvasGroup>();
        if ( buttonCanvasGroup == null ) {
            buttonCanvasGroup = startButton.gameObject.AddComponent<CanvasGroup>();
        }

        buttonCanvasGroup.alpha = 0f;

        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0, 0, 0, 1);

        StartCoroutine(FadeIn());
    }
    void Update() {
    }
    IEnumerator FadeIn() {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while ( elapsedTime < fadeDuration ) {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);

            // 이미지 페이드 인
            fadeColor.a = alpha;
            fadeImage.color = fadeColor;

            // 버튼 페이드 인
            buttonCanvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);

            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
        fadeImage.gameObject.SetActive(false);
        buttonCanvasGroup.alpha = 1f;
    }
    public void SceneChange() {
        SceneManager.LoadScene("SampleScene");
    }
}
