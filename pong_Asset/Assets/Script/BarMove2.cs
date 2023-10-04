
using UnityEngine;


public class BarMove2 : MonoBehaviour
{
    
    Transform tr;
    public Rigidbody2D tg;
    public BallMove Ball;
    public int BouncePosition;  // 0은 위, 1은 아래
    public static int mode = 2;
    public static float dif = 0f;
    public static bool modecheck = false;
    public static bool middle = false;
    public void Easy()
    {
        dif = 0.4f;
        modecheck = true;
    }
    public void Medium()
    {
        dif = 0.4f;
        middle = true;
        modecheck = true;
    }
    public void Hard()
    {
        dif = 0.7f;
        middle = true;
        modecheck = true;
    }

    public void OneP()
    {
        mode = 1;
        modecheck = false;
}
    public void TwoP()
    {
        mode = 0;
        modecheck = true;
    }
    public int Win()
    {
        if(mode == 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public void Mode2()
    {
        mode = 2;
    }
    public void middleCheck()
    {
        middle = false;
    }

    void Start()
    {
        tr = GetComponent<Transform>();
        tg = GetComponent<Rigidbody2D>();
        tr.position = new Vector2(8, 0);

    }
    void Update()
    {

            if (mode == 0 && modecheck == true)
            {
                if (tr.position.y < 4 && Time.timeScale > 0)
                {

                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        tr.position = new Vector2(8, tr.position.y + Time.deltaTime * 10);

                    }
                }
                if (tr.position.y > -4 && Time.timeScale > 0)
                {
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        tr.position = new Vector2(8, tr.position.y - Time.deltaTime * 10);
                    }
                }
            }



            if (mode == 1 && modecheck == true)
            {
                if (Ball.rg.velocity.x > 0)
                {
                    if (tr.position.y < 4 && Time.timeScale > 0)
                    {
                        if (BouncePosition == 0)
                        {
                            if (Ball.transform.position.y > tr.position.y + Random.Range(0.0f, 0.8f))
                            {
                                tr.position = new Vector2(8, tr.position.y + Time.deltaTime * 10 * dif);
                            }
                        }
                        else
                        {
                            if (Ball.transform.position.y > tr.position.y - Random.Range(0.0f, 0.8f))
                            {
                                tr.position = new Vector2(8, tr.position.y + Time.deltaTime * 10 * dif);
                            }
                        }
                    }
                    if (tr.position.y > -4 && Time.timeScale > 0)
                    {

                        if (BouncePosition == 0)
                        {
                            if (Ball.transform.position.y < tr.position.y + Random.Range(0.0f, 0.8f))
                            {
                                tr.position = new Vector2(8, tr.position.y - Time.deltaTime * 10 * dif);
                            }
                        }
                        else
                        {
                            if (Ball.transform.position.y < tr.position.y - Random.Range(0.0f, 0.8f))
                            {
                                tr.position = new Vector2(8, tr.position.y - Time.deltaTime * 10 * dif);
                            }
                        }
                    }
                }
                else
                {
                    if(middle == true)
                    {
                        if (tr.position.y < 4 && Time.timeScale > 0)
                        {

                              if (0 > tr.position.y)
                              {
                                    tr.position = new Vector2(8, tr.position.y + Time.deltaTime * 10 * dif);

                               }
                         }
                         if (tr.position.y > -4 && Time.timeScale > 0)
                         {
                               if (0 < tr.position.y)
                               {
                                    tr.position = new Vector2(8, tr.position.y - Time.deltaTime * 10 * dif);
                               }
                         }
                    }
                    
                }
            }


        }
    
}