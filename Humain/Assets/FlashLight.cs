using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    //Faire une coroutine pour faire clignoter la lumiere de la lampe torche
    public Light flashLight;
    public float minIntensity;
    public float maxIntensity;    

    [SerializeField] private float _batteryLife = 100f;

    void Start()
    {
        StartCoroutine("LetTheLightFlash");
        print("Start");
    }

    IEnumerator LetTheLightFlash()
    {
        while (true)
        {
            flashLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(0.11f);
            DecreaseBattery();


            if (_batteryLife <= 0)
            {
                print("Fini");
            }

        }            
    }
    
    //Faire baisser la batterie si la lampe est allumee
    public void DecreaseBattery()
    {
        _batteryLife -= 0.01f;
    }

    //Ajouter une pile a la lampe torche
    public void AddBattery()
    {
        _batteryLife = 100f;
    }
}
