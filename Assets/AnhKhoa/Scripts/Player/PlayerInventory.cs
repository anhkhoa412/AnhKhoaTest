using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{


    public InventoryItemBase mCurrentItem = null;

    public Inventory Inventory;

    public GameObject Hand;

    public EItemType currentItemType;

    [SerializeField] private Animator anim;
    // Use this for initialization
    void Start()
    {

        Inventory.ItemUsed += Inventory_ItemUsed;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
      //  anim = GetComponent<Animator>();

    }

    private void Update()
    {
        
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        InventoryItemBase item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;

        if (item == mCurrentItem)
            mCurrentItem = null;

    }

    private void SetItemActive(InventoryItemBase item, bool active)
    {
        GameObject currentItem = (item as MonoBehaviour).gameObject;
        currentItem.SetActive(active);
        currentItem.transform.parent = active ? Hand.transform : null;

        //if (currentItem != null)
        //{
        //    anim.SetBool("gunHolding", true);
        //}
    }


    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        if (e.Item.ItemType != EItemType.Consumable)
        {
            // If the player carries an item, un-use it (remove from player's hand)
            if (mCurrentItem != null)
            {
                SetItemActive(mCurrentItem, false);
                mCurrentItem.isUsing = false;
            }

            InventoryItemBase item = e.Item;

            // Use item (put it to hand of the player)
            SetItemActive(item, true);

            mCurrentItem = e.Item;
            e.Item.isUsing = true;
        }

        if (e.Item.ItemType == EItemType.Weapon) {
            anim.SetBool("gunHolding", true);
        }

    }



    //public void DropCurrentItem()
    //{

    //    GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;

    //    Inventory.RemoveItem(mCurrentItem);

    //    // Throw animation
    //    Rigidbody rbItem = goItem.AddComponent<Rigidbody>();
    //    if (rbItem != null)
    //    {
    //        rbItem.AddForce(transform.forward * 2.0f, ForceMode.Impulse);

    //        Invoke("DoDropItem", 0.25f);
    //    }
    //}

    //public void DropAndDestroyCurrentItem()
    //{
    //    GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;

    //    Inventory.RemoveItem(mCurrentItem);

    //    Destroy(goItem);

    //    mCurrentItem = null;
    //}

    //public void DoDropItem()
    //{

    //    if (mCurrentItem != null)
    //    {
    //        // Remove Rigidbody
    //        Destroy((mCurrentItem as MonoBehaviour).GetComponent<Rigidbody>());

    //        mCurrentItem = null;


    //    }
    //}



    public bool CarriesItem(string itemName)
    {
        if (mCurrentItem == null)
            return false;

        return (mCurrentItem.Name == itemName);
    }

    public InventoryItemBase GetCurrentItem()
    {
        return mCurrentItem;
    }

    public bool IsArmed
    {
        get
        {
            if (mCurrentItem == null)
                return false;

            return mCurrentItem.ItemType == EItemType.Weapon;
        }
    }


    //void FixedUpdate()
    //{
    //    // Drop item
    //    if (mCurrentItem != null && Input.GetKeyDown(KeyCode.R))
    //    {
    //        DropCurrentItem();
    //    }

    //}




    public void InteractWithItem()
    {
        if (mInteractItem != null)
        {
            mInteractItem.OnInteract();

            if (mInteractItem is InventoryItemBase)
            {
                InventoryItemBase inventoryItem = mInteractItem as InventoryItemBase;
                Inventory.AddItem(inventoryItem);
                inventoryItem.OnPickup();

                if (inventoryItem.UseItemAfterPickup)
                {
                    Inventory.UseItem(inventoryItem);
                }
             
                mInteractItem = null;
            }
            //else
            //{
            //    if (mInteractItem.ContinueInteract())
            //    {
            //        Hud.OpenMessagePanel(mInteractItem);
            //    }
            //    else
            //    {
            //        Hud.CloseMessagePanel();
            //        mInteractItem = null;
            //    }
            //}
        }
    }

    private InteractableItemBase mInteractItem = null;

    private void OnTriggerEnter(Collider other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();

        if (item != null)
        {
            if (item.CanInteract(other))
            {
                mInteractItem = item;

            }
        }

        if (mInteractItem != null)
        {
            mInteractItem.OnInteract();

            if (mInteractItem is InventoryItemBase)
            {
                InventoryItemBase inventoryItem = mInteractItem as InventoryItemBase;
                Inventory.AddItem(inventoryItem);
                inventoryItem.OnPickup();

                if (inventoryItem.UseItemAfterPickup)
                {
                    Inventory.UseItem(inventoryItem);
                }

                mInteractItem = null;
            }
        }
    }

    private void TryInteraction(Collider other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();

        if (item != null)
        {
            if (item.CanInteract(other))
            {
                mInteractItem = item;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();
        if (item != null)
        {
            
            mInteractItem = null;
        }
    }
}
