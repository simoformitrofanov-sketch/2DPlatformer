using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    private void OnDestroy()
    {
        Collected = null;
    }

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
