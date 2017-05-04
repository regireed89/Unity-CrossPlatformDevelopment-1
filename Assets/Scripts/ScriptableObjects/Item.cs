using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableAssets
{
    [CreateAssetMenu(fileName = "Item.cs", menuName = "Item")]
    public class Item : ScriptableObjects
    {
        protected string name;
        protected string id;
    }
}

