using UnityEngine;
using UnityEngine.UI;

public class MapSelection : ScrollableMenu
{
    [SerializeField] PlayerVictories victories;

    private new void Awake()
    {
        base.Awake();
        victories.mapIndex = i;
    }

    public new void Next()
    {
        base.Next();
        victories.mapIndex = i;
    }

    public new void Previous()
    {
        base.Previous();
        victories.mapIndex = i;
    }



}
