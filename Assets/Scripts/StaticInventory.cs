using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInventory
{
    //private static float[] priceArr;
    //private static string[] itemNameArr;
    //private static string[] descriptionArr;
    //private static Sprite[] spriteImageArr;
    private static List<Item> itemArry;
    public static List<Item> ItemArry
    {
        get
        {
            return itemArry;
        }

        set
        {
            itemArry = value;
        }
    }

    //public static float[] PriceArr
    //{
    //    get
    //    {
    //        return priceArr;
    //    }

    //    set
    //    {
    //        priceArr = value;
    //    }
    //}

    //public static string[] ItemNameArr
    //{
    //    get
    //    {
    //        return itemNameArr;
    //    }

    //    set
    //    {
    //        itemNameArr = value;
    //    }
    //}

    //public static string[] DescriptionArr
    //{
    //    get
    //    {
    //        return descriptionArr;
    //    }

    //    set
    //    {
    //        descriptionArr = value;
    //    }
    //}

    //public static Sprite[] SpriteImageArr
    //{
    //    get
    //    {
    //        return spriteImageArr;
    //    }

    //    set
    //    {
    //        spriteImageArr = value;
    //    }
    //}
}
