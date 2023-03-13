using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject textTitle; // ���� Ÿ��Ʋ �ؽ�Ʈ UI ������Ʈ
    [SerializeField]
    private GameObject textTapToPlay; // "TAP TO PLAY" �ؽ�Ʈ UI ������Ʈ

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
        // ���콺 ���� ��ư�� ���� ������ while() �ݺ��� ���
        while ( true )
        {
            // ���콺 ���� ��ư�� ������ GameStart() �޼ҵ带 �����ϰ� �ڷ�ƾ break
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
        // ���� Ÿ��Ʋ�� "TAP TO PLAY" �ؽ�Ʈ�� ������ �ʰ�
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
