using UnityEngine;

public class playercontroller : MonoBehaviour


{
    public float transform.position{}
    
    void Start()
    {
        
    }

    void Update()
    {
        while (Input.GetKey(W))
        {
            transform.position += Vector2(0f, 5f);
        }
    }

}
