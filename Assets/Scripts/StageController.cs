using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject textTitle; // 게임 타이틀 텍스트 UI 오브젝트
    [SerializeField]
    private GameObject textTapToPlay; // "TAP TO PLAY" 텍스트 UI 오브젝트

    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    [SerializeField]
    private TextMeshProUGUI textBestScore;
    [SerializeField]
    private GameObject buttonContinue;
    [SerializeField]
    private GameObject textScoreText;

    private int currentScore = 0;

    public bool IsGameOver { private set; get; } = false;

    private IEnumerator Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textBestScore.text = $"<size=50>BEST</size>\n<size=100>{bestScore}</size>";
        // 마우스 왼쪽 버튼을 누를 때까지 while() 반복문 재생
        while ( true )
        {
            // 마우스 왼쪽 버튼을 누르면 GameStart() 메소드를 실행하고 코루틴 break
            if ( Input.GetMouseButtonDown(0) )
            {
                GameStart();

                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        // 게임 타이틀과 "TAP TO PLAY" 텍스트를 보이지 않게
        textTitle.SetActive(false);
        textTapToPlay.SetActive(false);
        textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        IsGameOver = true;
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if(currentScore>bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            textBestScore.text = $"<size=50>BEST</size>\n<size=100>{currentScore}</size>";
        }
        buttonContinue.SetActive(true);
        textScoreText.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;

        textCurrentScore.text = currentScore.ToString();
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
