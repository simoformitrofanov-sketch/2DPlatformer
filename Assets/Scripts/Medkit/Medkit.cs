using System;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public event Action<Medkit> Collected;

    private void OnDestroy()
    {
        Collected = null;
    }

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}