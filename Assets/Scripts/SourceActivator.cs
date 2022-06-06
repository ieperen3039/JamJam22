using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceActivator : MonoBehaviour
{
    private bool wellActive = false;
    private bool factoryActive = false;

    [SerializeField]
    private WaterSourcePlacer _placer;

    public void MakeWellActive()
    {
        _placer.ClearActiveSource();
        _placer.MakeWellSourceActive(!wellActive);
        wellActive = !wellActive;
    }

    public void MakeFactoryActive()
    {
        _placer.ClearActiveSource();
        _placer.MakeFactorySourceActive(!factoryActive);
        factoryActive = !factoryActive;

    }
}
