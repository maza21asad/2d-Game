using UnityEngine;

public class CCoin : Collectables
{
    [SerializeField] private int coinsToAdd = 20;
    
    protected override void Pick()
    {
           AddCoins();
    }

    private void AddCoins()
    {
        CoinManager.Instance.AddCoins(coinsToAdd);
    }
}
