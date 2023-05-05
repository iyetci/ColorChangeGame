using UnityEngine;
using UnityEngine.UI;

public class ImageColorTransition : MonoBehaviour
{
    public Color startColor = Color.white; // baþlangýç rengi
    public Color secondColor = Color.red; // ikinci renk
    public Color thirdColor = Color.blue; // üçüncü renk
    public Color endColor = Color.black; // bitiþ rengi
    public float transitionTime = 1.0f; // geçiþ süresi
    private float timer = 0.0f; // zamanlayýcý
    private Image image; // Image bileþeni referansý

    private void Start()
    {
        // Image bileþeni referansýný al
        image = GetComponent<Image>();
    }

    private void Update()
    {
        // zamanlayýcý kontrolü
        timer += Time.deltaTime;

        // zamanlayýcý süresi, geçiþ süresinden büyükse renklerin yerini deðiþtir ve zamanlayýcýyý sýfýrla
        if (timer >= transitionTime)
        {
            Color temp = endColor;
            endColor = startColor;
            startColor = secondColor;
            secondColor = thirdColor;
            thirdColor = temp;
            timer = 0.0f;
        }

        // geçiþ süresi boyunca renkleri deðiþtir
        float t = timer / transitionTime;
        if (t <= 0.33f)
        {
            image.color = Color.Lerp(startColor, secondColor, t * 3);
        }
        else if (t <= 0.67f)
        {
            image.color = Color.Lerp(secondColor, thirdColor, (t - 0.33f) * 3);
        }
        else
        {
            image.color = Color.Lerp(thirdColor, endColor, (t - 0.67f) * 3);
        }
    }
}