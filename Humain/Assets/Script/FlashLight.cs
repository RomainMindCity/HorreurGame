using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    //Faire une coroutine pour faire clignoter la lumiere de la lampe torche
    public Light flashLight;
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;
    [SerializeField] int range;

    [SerializeField] private float _batteryLife = 100f;
    

    void Start()
    {
        //StartCoroutine("LetTheLightFlash");
        print("Start");
        flashLight.range = range;
        FindObjectOfType<SoundManager>().Play("FlashLight");

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashLight.enabled = !flashLight.enabled;
            if (flashLight.enabled)
            {
                StartCoroutine("LetTheLightFlash");
                FindObjectOfType<SoundManager>().Play("FlashLight");
            }
            else
            {
                StopCoroutine("LetTheLightFlash");
                FindObjectOfType<SoundManager>().Stop("FlashLight");
            }
        }
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

    //Faire une fonction pour renvoyer la valeur de la batterie
    public float GetBatteryLife()
    {
        return _batteryLife;
    }
}
