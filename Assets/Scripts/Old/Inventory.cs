// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Inventory {

//     private Dictionary<Resources,List<CollectibleObject>> resources;
//     private Dictionary<CollectibleObject.Type,List<CollectibleObject>> inventory;

    
//     /*
//     Inventory used dictionary to speed up access times. All default inventory items are loaded at instanciation.
//     */
//     public Inventory(){
//         inventory =  new Dictionary<CollectibleObject.Type,List<CollectibleObject>>();
//         foreach(CollectibleObject.Type collectible in Enum.GetValues(typeof(Collectible.Type))){
//             inventory[collectible] = new List<CollectibleObject>();
//         };

//         Debug.Log("Inventory Constructed");
//     }

//     /*    
//     Append item to the list of items collected for given collectible.
//     */
//     public void AddItem(CollectibleObject collectible){
//         CollectibleObject.Type type = collectible.collectibleType;
//         inventory[type].Add(collectible);
//         Debug.Log("Added item " + type.ToString());
//     }

//     /*
//     Remove the last item for a given collectible. This method can be used when applying the efffect of collected items or simply storing the quantity
//     */
//     public void RemoveItem(CollectibleObject collectible){
//         CollectibleObject.Type type = collectible.collectibleType;
//         int lastIndex = inventory[type].Count - 1;
//         inventory[type].RemoveAt(lastIndex);
//     }

//     public List<CollectibleObject> getCollectibleList(CollectibleObject.Type collectibleType){
//         return inventory[collectibleType];
//     }

// }
