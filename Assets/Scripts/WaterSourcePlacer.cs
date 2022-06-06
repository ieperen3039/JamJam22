using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSourcePlacer : MonoBehaviour
{
    [SerializeField]
    private WaterSource WellSource;
    [SerializeField]
    private WaterSource FactorySource;

    private WaterSource activeSourcePrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClearActiveSource()
    {
        activeSourcePrefab = null;
    }

    public void MakeWellSourceActive(bool makeActive)
    {
        if (activeSourcePrefab == null && makeActive == true)
        {
            Debug.Log("WellSource now active");
            activeSourcePrefab = WellSource;
        }
    }    
    
    public void MakeFactorySourceActive(bool makeActive)
    {
        if (activeSourcePrefab == null && makeActive == true)
        {
            Debug.Log("FactorySource now active");
            activeSourcePrefab = FactorySource;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && activeSourcePrefab != null)
        {
            Vector3 mousePos = Input.mousePosition;

            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mousePos);
            spawnPos.z = 10;

            Instantiate(activeSourcePrefab, spawnPos, Quaternion.identity);
        }
    }
}