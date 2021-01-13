

namespace BL.StandardDictionary
{
    /// <summary>
    /// 仪器设备类别(补充)
    /// </summary>
    public class DicEquipmentType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","教学仪器设备")
            };
        }
    }
}
