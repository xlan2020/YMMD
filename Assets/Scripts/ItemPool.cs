using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity{
    N,
    R,
    SR,
}
public class ItemPool : MonoBehaviour
{

    [SerializeField]GameManager gameManager;
    [SerializeField] ItemPoolScriptableObject[] pools;



    public void DisplaceOutItemForPriceRank(int priceRank){
        ItemScriptableObject newItem = DrawItemForPriceRank(priceRank);
        gameManager.AddMoney(-priceRank);
        gameManager.AddItemToInventory(newItem);
    }


    public ItemScriptableObject DrawItemForPriceRank(int priceRank){

        for(int i = 0; i<pools.Length; i++){
            if (pools[i].priceRank == priceRank){
                return drawRandRareItemFromPool(pools[i]);
            }
        }

        UnityEngine.Debug.LogWarning("pool attached to the given price rank is not found!");
        return null;
    }

    private ItemScriptableObject drawRandRareItemFromPool(ItemPoolScriptableObject pool){

        Rarity randRarity = decideDrawRarity();

        if (randRarity== Rarity.R && pool.items_R.Length == 0){
            // then draw a normal one
            return drawItemForRarity(pool, Rarity.N);
        }
            if (randRarity == Rarity.SR && pool.items_SR.Length == 0){
            // then draw a normal one
            return drawItemForRarity(pool, Rarity.N);
        }

        return drawItemForRarity(pool, randRarity);
    }

    private ItemScriptableObject drawItemForRarity(ItemPoolScriptableObject pool, Rarity rarity){
        int rand = 0;
        switch (rarity){
            case Rarity.N: 
                rand = Random.Range(0, pool.items_N.Length);
                return pool.items_N[rand];
            case Rarity.R:
                rand = Random.Range(0, pool.items_R.Length);
                return pool.items_R[rand];
            case Rarity.SR: 
                rand = Random.Range(0, pool.items_SR.Length);
                return pool.items_SR[rand];
            default:
                return null;
        }
    }
    
    private Rarity decideDrawRarity(){
        int rand_100 = Random.Range(0, 100);

        if (rand_100 < 2){
            return Rarity.SR;
        } else if (rand_100 < 10){
            return Rarity.R;
        } else{
            return Rarity.N;
        }
    }

}
