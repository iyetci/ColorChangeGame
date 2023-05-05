using UnityEngine;
using UnityEngine.UI;

public class SpriteColorTransition : MonoBehaviour
{
    public Color startColor = Color.white; // ba�lang�� rengi
    public Color secondColor = Color.red; // ikinci renk
    public Color thirdColor = Color.green; // ���nc� renk
    public Color endColor = Color.black; // biti� rengi
    public float transitionTime = 1.0f; // ge�i� s�resi
    private float timer = 0.0f; // zamanlay�c�
    private SpriteRenderer spriteRenderer; // SpriteRenderer bile�eni referans�

    private void Start()
    {
        // SpriteRenderer bile�eni referans�n� al
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // zamanlay�c� kontrol�
        timer += Time.deltaTime;

        // zamanlay�c� s�resi, ge�i� s�resinden b�y�kse renklerin yerini de�i�tir ve zamanlay�c�y� s�f�rla
        if (timer >= transitionTime)
        {
            Color temp = endColor;
            endColor = thirdColor;
            thirdColor = secondColor;
            secondColor = startColor;
            startColor = temp;
            timer = 0.0f;
        }

        // ge�i� s�resi boyunca renkleri de�i�tir
        float t = timer / transitionTime;
        Color lerpedColor = Color.Lerp(startColor, secondColor, t);
        if (t > 0.5f)
        {
            lerpedColor = Color.Lerp(secondColor, thirdColor, t * 2.0f - 1.0f);
        }
        spriteRenderer.color = lerpedColor;
    }
}