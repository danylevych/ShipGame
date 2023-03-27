using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class ShipManager : ScriptableObject
{
    public Ship[] ships;

    public int ShipsCount
    {
        get
        {
            return ships.Length;
        }
    }

    public Ship GetShip(int index)
    {
        return ships[index];
    }
}
