using PlayerItems;
using UnityEngine;

namespace Player
{
    public class PlayerEquipment : MonoBehaviour
    {
        public PlayerMain playerMain;

        public Gun CurrentWeapon { get; private set; } = new Pistol();
    }
}