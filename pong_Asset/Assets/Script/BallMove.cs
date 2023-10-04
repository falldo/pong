
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float StartSpeed = 5.0f;
    private float PlusSpeed = 0.5f;
    public float MaxSpeed = 10.0f;
    private int hit = 0;
    private float BallSpeed;
    public  Rigidbody2D rg;
    public SpriteRenderer rb;
    GameObject GM;
    public BarMove2 BM2;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        rb = GetComponent<SpriteRenderer>();
        GM = GameObject.Find("GameManager");
    }
    private void Start()
    {
        Reset();
    }
    private void Update()
    {
      
    }
    void OnCollisionEnter2D(Collision2D Ball)
    {
        Vector2 Ballposition = transform.position;
        Vector2 Barposition = Ball.transform.position;
        float Barsize = Ball.collider.bounds.size.y;
        float BalldirX;

        if (Ball.collider.gameObject.CompareTag("Left_Wall"))
        {
            GM.GetComponent<GameManager>().RightScore_up();
        }
        if (Ball.collider.gameObject.CompareTag("Right_Wall"))
        {
            GM.GetComponent<GameManager>().LeftScore_up();
        }
        if ((Ball.collider.gameObject.CompareTag("Bar1")|| Ball.collider.gameObject.CompareTag("Bar2") )&& StartSpeed + hit * PlusSpeed <= MaxSpeed)
        {
            hit++;
            BM2.BouncePosition = Random.Range(0, 2);
            
            if (Ball.collider.gameObject.CompareTag("Bar1"))
            {
                BalldirX = 1;
                float BalldirY = (Ballposition.y - Barposition.y) / Barsize;
                speedUp(new Vector2(BalldirX, BalldirY));
                Debug.Log("1 check");
            }
            if (Ball.collider.gameObject.CompareTag("Bar2"))
            {
                BalldirX = -1;
                float BalldirY = (Ballposition.y - Barposition.y) / Barsize;
                speedUp(new Vector2(BalldirX, BalldirY));
                Debug.Log("2 check");
            }
        } 
    }
    
    public void Reset()
    {
        rg.position = new Vector2(0, 0); // 공 원래자리로 송환
        rg.velocity = new Vector2(0, 0); // 공 속도 초기화
        hit = 0; // 충돌횟수 초기화
        StartBounce();
        Invoke("White", 0.02f);
        
    }
   private void StartBounce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f; //공 시작 방향 랜덤
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        speedUp(direction);
    }
    private void White()
    {
          rb.color = Color.white;
          
    }
    public void speedUp(Vector2 direction)
    {
        direction = direction.normalized;
        BallSpeed = StartSpeed + hit * PlusSpeed;
        rg.velocity = direction * BallSpeed;
        Debug.Log(rg.velocity.magnitude);
    }
}
