using UnityEngine;

public class LoopingBackgroundImage : MonoBehaviour
{
    public float backgroundSpeed; 
    public Renderer BackgroundRenderer;

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2 (backgroundSpeed * Time.deltaTime, 0f);
    }
}
