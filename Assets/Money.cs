using UnityEngine;

public class Money : MonoBehaviour
{
    public float money = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<MoneyComponent>().AddMoney(money);
        Destroy(gameObject);
    }
}
