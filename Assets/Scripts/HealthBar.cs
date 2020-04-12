using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 10;
    [SerializeField] private float _healValue = 10;
    [SerializeField] private float _damageValue = 10;
    [SerializeField] private float _maxHealth = 100;

    private Slider _slider;
    private float _health;

    private float Health 
    {
        get 
        {
            return _health;
        }
        set
        {
            if (value > _maxHealth)
                _health = _maxHealth;
            else if (value < 0)
                _health = 0;
            else
                _health = value;
        }
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health = _maxHealth;
    }

    public void OnHealButtonClick()
    {
        Health += _healValue;
    }

    public void OnDamageButtonClick()
    {
        Health -= _damageValue;
    }

    private void Update()
    {
        HealthChange();
    }

    private void HealthChange()
    {
        _slider.value = Mathf.Lerp(_slider.value, Health / _maxHealth, _lerpSpeed * Time.deltaTime);
    }
}
