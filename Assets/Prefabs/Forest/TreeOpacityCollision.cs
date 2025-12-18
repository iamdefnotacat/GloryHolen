using UnityEngine;

public class TreeOpacityCollision : MonoBehaviour
{
    [SerializeField] private float fadeAlpha = 0.4f;
    [SerializeField] private float fadeSpeed = 8f;

    private SpriteRenderer spriteRenderer;
    private float targetAlpha = 1f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Color c = spriteRenderer.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, fadeSpeed * Time.deltaTime);
        spriteRenderer.color = c;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetAlpha = fadeAlpha;
            Debug.Log("Player entered tree area");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetAlpha = 1f;
            Debug.Log("Player exited tree area");
        }
    }
}
