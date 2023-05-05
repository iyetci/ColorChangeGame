using UnityEngine;
using UnityEngine.UI;

public class SpriteColorTransition : MonoBehaviour
{
    public Color startColor = Color.white; // baþlangýç rengi
    public Color secondColor = Color.red; // ikinci renk
    public Color thirdColor = Color.green; // üçüncü renk
    public Color endColor = Color.black; // bitiþ rengi
    public float transitionTime = 1.0f; // geçiþ süresi
    private float timer = 0.0f; // zamanlayýcý
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileþeni referansý

    private void Start()
    {
        // SpriteRenderer bileþeni referansýný al
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // zamanlayýcý kontrolü
        timer += Time.deltaTime;

        // zamanlayýcý süresi, geçiþ süresinden büyükse renklerin yerini deðiþtir ve zamanlayýcýyý sýfýrla
        if (timer >= transitionTime)
        {
            Color temp = endColor;
            endColor = thirdColor;
            thirdColor = secondColor;
            secondColor = startColor;
            startColor = temp;
            timer = 0.0f;
        }

        // geçiþ süresi boyunca renkleri deðiþtir
        float t = timer / transitionTime;
        Color lerpedColor = Color.Lerp(startColor, secondColor, t);
        if (t > 0.5f)
        {
            lerpedColor = Color.Lerp(secondColor, thirdColor, t * 2.0f - 1.0f);
        }
        spriteRenderer.color = lerpedColor;
    }
}