using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bebaSpace
{
    public class GameEvents : MonoBehaviour
    {
        //public static System.Action SaveInitiated;
        //public static System.Action ClearNotification;
        //public static System.Action<Item> UseItem;

        public static System.Action PlayerThrowShuriken;

        public static void OnPlayerThrowShuriken() { PlayerThrowShuriken?.Invoke(); }

        //public static void OnSaveInitiated()
        //{
        //    SaveInitiated?.Invoke();
        //}

        //public static void OnUseItemInitiated(Item item)
        //{
        //    UseItem?.Invoke(item);
        //}

        //public static void OnClearNotificationInitiated()
        //{
        //    ClearNotification?.Invoke();
        //}
    }
}
