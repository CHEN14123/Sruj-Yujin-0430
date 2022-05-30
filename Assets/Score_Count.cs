using UnityEngine;
using UnityEngine.UI;

public class Score_Count : MonoBehaviour
{
    public Text Score;
        
    public Ball_Controller_2 Player;

    // Update is called once per frame
    public void Update()
    {
        //Player = new Ball_Controller_2();
        //Debug.Log("TEXT : "+ Player.count_green.ToString());
        Score.text = "BLACK SCORE:" + Ball_Controller_2.count_black.ToString() + "\n" +  "WHITE SCORE:" + Ball_Controller_2.count_white.ToString() + "\n" + "GREEN SCORE:" + Ball_Controller_2.count_green.ToString();
        //Score.text = "SCORE:" + Ball_Controller_2.count.ToString();
        //ScoreText_white.text = "SCORE:" + Player.count_white.ToString();

    }
}
