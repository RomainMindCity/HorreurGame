using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{

    //Recuperer la valeur de la batterie de la lampe torche
    public FlashLight flashLight;
    public TextMeshProUGUI batteryLifeText;

    void Start()
    {
        StartCoroutine("UpdateBatteryLife");
    }

    IEnumerator UpdateBatteryLife()
    {
        while (true)
        {
            batteryLifeText.text = (int)flashLight.GetBatteryLife() + "%";
            yield return new WaitForSeconds(0.1f);
        }
    }
}
