using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    private float fadeTime; // 페이드 되는 시간
    private TextMeshProUGUI textFade; // 페이드 효과에 사용되는 Text

    private void Awake()
    {
        textFade = GetComponent<TextMeshProUGUI>();

        // Fade In <-> Fade Out 무한 반복
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while ( true )
        {
            // 알파 값이 1에서 0으로 text가 보이지 않는다.
            yield return StartCoroutine(Fade(1, 0));

            // 알파 값이 0에서 1로 text가 보인다.
            yield return StartCoroutine(Fade(0, 1));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while ( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = textFade.color;
            color.a = Mathf.Lerp(start, end, percent);
            textFade.color = color;

            yield return null;
        }
    }
}
