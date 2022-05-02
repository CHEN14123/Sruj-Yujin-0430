using UnityEngine;
using UnityEngine.UI;

public class PositionZ : MonoBehaviour
{
    public Transform Player;
    public Text ScoreText;
    // Update is called once per frame
    public void Update()
    {
        //Shows the position of the ball
        ScoreText.text = "POSITION (Z):" + Player.position.z.ToString("0");
       
    }
}
