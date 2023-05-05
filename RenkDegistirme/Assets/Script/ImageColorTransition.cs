using UnityEngine;
using UnityEngine.UI;

public class ImageColorTransition : MonoBehaviour
{
    public Color startColor = Color.white; // ba�lang�� rengi
    public Color secondColor = Color.red; // ikinci renk
    public Color thirdColor = Color.blue; // ���nc� renk
    public Color endColor = Color.black; // biti� rengi
    public float transitionTime = 1.0f; // ge�i� s�resi
    private float timer = 0.0f; // zamanlay�c�
    private Image image; // Image bile�eni referans�

    private void Start()
    {
        // Image bile�eni referans�n� al
        image = GetComponent<Image>();
    }

    private void Update()
    {
        // zamanlay�c� kontrol�
        timer += Time.deltaTime;

        // zamanlay�c� s�resi, ge�i� s�resinden b�y�kse renklerin yerini de�i�tir ve zamanlay�c�y� s�f�rla
        if (timer >= transitionTime)
        {
            Color temp = endColor;
            endColor = startColor;
            startColor = secondColor;
            secondColor = thirdColor;
            thirdColor = temp;
            timer = 0.0f;
        }

        // ge�i� s�resi boyunca renkleri de�i�tir
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