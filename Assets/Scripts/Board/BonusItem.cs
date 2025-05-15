using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    public enum eBonusType
    {
        NONE,
        HORIZONTAL,
        VERTICAL,
        ALL
    }

    public eBonusType ItemType;

    public void SetType(eBonusType type)
    {
        ItemType = type;
    }

    protected override string GetPrefabName()
    {
        string prefabname = string.Empty;
        switch (ItemType)
        {
            case eBonusType.NONE:
                break;
            case eBonusType.HORIZONTAL:
                prefabname = Constants.PREFAB_BONUS_HORIZONTAL;
                break;
            case eBonusType.VERTICAL:
                prefabname = Constants.PREFAB_BONUS_VERTICAL;
                break;
            case eBonusType.ALL:
                prefabname = Constants.PREFAB_BONUS_BOMB;
                break;
        }

        return prefabname;
    }

    internal override bool IsSameType(Item other)
    {
        BonusItem it = other as BonusItem;
        return it != null && it.ItemType == this.ItemType;
    }

    internal override void ExplodeView()
    {
        base.ExplodeView(); // chạy hiệu ứng nổ
    }

    // ✅ Hàm để xác định các ô bị ảnh hưởng (gom cell trước khi nổ toàn cục)
    public List<Cell> GetAffectedCells()
    {
        List<Cell> list = new List<Cell>();

        switch (ItemType)
        {
            case eBonusType.HORIZONTAL:
                list = GetHorizontalAffectedCells();
                break;
            case eBonusType.VERTICAL:
                list = GetVerticalAffectedCells();
                break;
            case eBonusType.ALL:
                list = GetBombAffectedCells();
                break;
        }

        return list;
    }

    private List<Cell> GetBombAffectedCells()
    {
        List<Cell> list = new List<Cell>();
        if (Cell.NeighbourBottom) list.Add(Cell.NeighbourBottom);
        if (Cell.NeighbourUp) list.Add(Cell.NeighbourUp);
        if (Cell.NeighbourLeft)
        {
            list.Add(Cell.NeighbourLeft);
            if (Cell.NeighbourLeft.NeighbourUp) list.Add(Cell.NeighbourLeft.NeighbourUp);
            if (Cell.NeighbourLeft.NeighbourBottom) list.Add(Cell.NeighbourLeft.NeighbourBottom);
        }
        if (Cell.NeighbourRight)
        {
            list.Add(Cell.NeighbourRight);
            if (Cell.NeighbourRight.NeighbourUp) list.Add(Cell.NeighbourRight.NeighbourUp);
            if (Cell.NeighbourRight.NeighbourBottom) list.Add(Cell.NeighbourRight.NeighbourBottom);
        }
        return list;
    }

    private List<Cell> GetVerticalAffectedCells()
    {
        List<Cell> list = new List<Cell>();
        Cell newcell = Cell;

        while ((newcell = newcell.NeighbourUp) != null)
        {
            list.Add(newcell);
        }

        newcell = Cell;
        while ((newcell = newcell.NeighbourBottom) != null)
        {
            list.Add(newcell);
        }

        return list;
    }

    private List<Cell> GetHorizontalAffectedCells()
    {
        List<Cell> list = new List<Cell>();
        Cell newcell = Cell;

        while ((newcell = newcell.NeighbourRight) != null)
        {
            list.Add(newcell);
        }

        newcell = Cell;
        while ((newcell = newcell.NeighbourLeft) != null)
        {
            list.Add(newcell);
        }

        return list;
    }
}
