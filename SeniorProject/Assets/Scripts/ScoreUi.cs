using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    
    public RowUi rowUi;
    public ScoreManager scoreManager;
    
    void Start()
    {
        scoreManager.AddScore(new Score(name:"Adil",score:25));
        scoreManager.AddScore(new Score(name:"Calvin",score:80));
        scoreManager.AddScore(new Score(name:"Anant",score:50));
        
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}