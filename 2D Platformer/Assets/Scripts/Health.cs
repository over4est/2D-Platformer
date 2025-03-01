using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void RestoreHealth(int restoreValue)
    {
        if (restoreValue < 0)
        {
            return;
        }

        _currentHealth += restoreValue;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
