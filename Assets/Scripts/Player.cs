using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] UI_Inventory uiInventory;
    float horizontalInput;
    float verticalInput;
    Inventory inventory;
    Rigidbody2D rb;
    bool showInventory = false;
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        rb = gameObject.GetComponent<Rigidbody2D>();
        inventory.SetItemList(StaticInventory.ItemArry);
    }
    private void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontalInput * speed, verticalInput * speed));

        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
            uiInventory.gameObject.SetActive(showInventory);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        ItemInfo item = collision.GetComponent<ItemInfo>();
        if (item != null)// check if is item triggered
        {
            inventory.AddItem(item.GetItem());
            item.DestorySelf();

        }
    }
    public void SaveInventory()
    {
        StaticInventory.ItemArry = inventory.GetItemList();
    }
}
