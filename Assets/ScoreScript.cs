using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    [SerializeField] TextMeshProUGUI ScoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    // Update is called once per frame
    void UpdateScoreText()
    {
        ScoreText.text = " " + score;
    }
}
