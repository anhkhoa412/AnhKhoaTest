using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public void Updatebar(int currentBar, int maxBar)
    {
        fillBar.fillAmount = (float)currentBar / (float)maxBar;
        Debug.Log("Ouch");
    }
}
