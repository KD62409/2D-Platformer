using UnityEngine;

public class MoneyPack : MonoBehaviour
{
    public float Money = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<MoneyComponent>().AddMoney(Money);
        Destroy(gameObject);
    }
}
