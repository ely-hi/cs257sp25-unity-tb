using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    Image image;

    public Life targetLife;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (targetLife != null)
        {
            float fill = targetLife.amount / 100f;
            image.fillAmount = fill;
        }
    }
}
