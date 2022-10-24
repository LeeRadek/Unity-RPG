using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "new item";
    public Sprite icon = null;
    public bool isDefoultItem = false;

    public virtual void Use()
    {
        //Use the item
        //Something might happend

        Debug.Log("Used: " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
