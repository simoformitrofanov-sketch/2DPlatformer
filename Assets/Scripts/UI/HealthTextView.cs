using UnityEngine;
using TMPro;

public class HealthTextView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _health.Changed += Refresh;    
    }

    private void OnDisable()
    {
        _health.Changed -= Refresh;
    }

    private void Start()
    {
        Refresh(_health.Current, _health.Max);
    }

    private void Refresh(int current, int max)
    {
        _text.text = $"{current}/{max}";
    }
}
