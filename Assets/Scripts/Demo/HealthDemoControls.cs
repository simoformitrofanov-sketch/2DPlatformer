using UnityEngine;
using UnityEngine.UI;

public class HealthDemoControls : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private int _damage = 10;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(DealDamage);
        _healButton.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(DealDamage);
        _healButton.onClick.RemoveListener(Heal);
    }

    private void DealDamage()
    {
        _health.TakeDamage(_damage);
    }

    private void Heal()
    {
        _health.FullHeal();
    }
}