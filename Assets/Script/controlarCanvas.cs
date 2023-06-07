using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlarCanvas : MonoBehaviour
{
    public static controlarCanvas instance;

    public Image corazon1, corazon2, corazon3;
    public Sprite corazonfull, corazonvacio,corazonmedio;
    public Text coinText;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateCoinCount();
    }

    void Update()
    {

    }

    public void vercorazon()
    {
        switch (vida.instance.lowvida)
        {
            case 6:
                corazon1.sprite = corazonfull;
                corazon2.sprite = corazonfull;
                corazon3.sprite = corazonfull;

                break;
            case 5:
                corazon1.sprite = corazonfull;
                corazon2.sprite = corazonfull;
                corazon3.sprite = corazonmedio;

                break;
            case 4:
                corazon1.sprite = corazonfull;
                corazon2.sprite = corazonfull;
                corazon3.sprite = corazonvacio;

                break;
            case 3:
                corazon1.sprite = corazonfull;
                corazon2.sprite = corazonmedio;
                corazon3.sprite = corazonvacio;

                break;
            case 2:
                corazon1.sprite = corazonfull;
                corazon2.sprite = corazonvacio;
                corazon3.sprite = corazonvacio;

                break;
            case 1:
                corazon1.sprite = corazonmedio;
                corazon2.sprite = corazonvacio;
                corazon3.sprite = corazonvacio;

                break;
            case 0:
                corazon1.sprite = corazonvacio;
                corazon2.sprite = corazonvacio;
                corazon3.sprite = corazonvacio;

                break;
            default:
                corazon1.sprite = corazonvacio;
                corazon2.sprite = corazonvacio;
                corazon3.sprite = corazonvacio;

                break;

        }
    }

    //para el conteo
    public void UpdateCoinCount()
    {
        coinText.text = LevelManager.instance.iconsCollected.ToString();
    }

}
