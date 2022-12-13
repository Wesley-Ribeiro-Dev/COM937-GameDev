using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore(){
        int currentScore = int.Parse(highScoreText.text);
        currentScore++;
        highScoreText.text = currentScore.ToString();
    }
}
