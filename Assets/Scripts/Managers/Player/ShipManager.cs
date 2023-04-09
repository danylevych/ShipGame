using UnityEngine;


// +=========================================+
// |                                         |
// | This script create DB for the game, that|
// |        include the ships' info.         |
// |                                         |
// +=========================================+

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
