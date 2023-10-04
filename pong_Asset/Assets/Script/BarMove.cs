
using UnityEngine;

public class BarMove : MonoBehaviour
{
    Transform tr;
    Rigidbody2D tg;
    void Start()
    {
        
        tr = GetComponent<Transform>();
        tg = GetComponent<Rigidbody2D>();
        tr.position = new Vector2(-8, 0);
    }
    void Update()
    {
        if (tr.position.y < 4 && Time.timeScale > 0)
        {

            if (Input.GetKey(KeyCode.W))
            {
                tr.position = new Vector2(-8, tr.position.y + Time.deltaTime * 10); 
                
            }
        }
        if(tr.position.y > -4 && Time.timeScale > 0)
        {
            if (Input.GetKey(KeyCode.S))
            {
                tr.position = new Vector2(-8, tr.position.y - Time.deltaTime * 10);

            }
        }
            
        
    }
}
