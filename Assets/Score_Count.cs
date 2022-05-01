using UnityEngine;
using UnityEngine.UI;

public class Score_Count : MonoBehaviour
{
    public Text ScoreText;
    public BallController Player;

    // Update is called once per frame
    void Update()
    {
        //Player = new BallController();
        ScoreText.text = "SCORE:" + Player.count.ToString();
    }
}
