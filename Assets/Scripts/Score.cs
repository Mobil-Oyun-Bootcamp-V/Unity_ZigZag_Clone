using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int _score, _highScore, _gemAmount = 0;

    public static void Scored()
    {
        _highScore = PlayerPrefs.GetInt("highscore");
        _score++;
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("highscore", _highScore);
            PlayerPrefs.SetInt("gems", _gemAmount);

        }
    }

    public static int GetScore()
    {
        return _score;
    }

    public static int GetHScore()
    {
        return _highScore;
    }

    public static void ReceiptGem()
    {
        _score += 2;
        _gemAmount++;
    }
}
