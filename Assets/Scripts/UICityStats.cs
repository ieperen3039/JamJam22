using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICityStats : MonoBehaviour
{
    [SerializeField]
    private CityBehaviour _CityBehaviour;

    [SerializeField]
    private TMP_Text _TextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        _TextMeshPro.text = "Inhabitants: " + _CityBehaviour.Inhabitants;
    }

    public void HandleUpdate()
    {
        _TextMeshPro.text = "Inhabitants: " + _CityBehaviour.Inhabitants;
    }
}
