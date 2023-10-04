
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public BallMove ball;
    public BarMove2 bbmm;
    private int LeftScore = 0, RightScore = 0;
    public TMP_Text LeftScoreBoard;
    public TMP_Text RightScoreBoard;
    public TMP_Text wintext;
    public GameObject WinCanvas;
    public bool Result = false;

    void Start() {
        WinCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftScore_up()
    {
        LeftScore++;
        if(LeftScore == 5)
        {
            Result = true;
            Time.timeScale = 0f;
            WinCanvas.SetActive(true);
            if(bbmm.Win() ==1)
            {
                wintext.text = "You Win";

            }
            else if (bbmm.Win() == 0)
            {
                wintext.text = "Left Win";
            }
        }
        LeftScoreBoard.text = LeftScore.ToString();
        ball.rg.velocity = new Vector2(0, 0);
        ball.rb.color = Color.black;
        Invoke("BallReset", 2.0f);
    }
    public void RightScore_up()
    {
        RightScore++;
        if (RightScore == 5)
        {
            Result = true;
            Time.timeScale = 0f;
            WinCanvas.SetActive(true);
            if (bbmm.Win() == 1)
            {
                wintext.text = "You Lose";
            }
            else if (bbmm.Win() == 0)
            {
                wintext.text = "Right Win";
            }
        }
        RightScoreBoard.text = RightScore.ToString();
        ball.rg.velocity = new Vector2(0, 0);
        ball.rb.color = Color.black;
        Invoke("BallReset", 2.0f);
    }
    private void BallReset()
    {
        ball.Reset();
    }

}
