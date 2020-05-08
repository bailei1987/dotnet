
namespace BL.StandardDictionary
{
    /// <summary>
    /// 经费支出类别(补充)
    /// </summary>
    public class DicMoneyOutSort : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","专项经费"),
                new DicItem("02","日常教学经费"),
                new DicItem("03","教科研经费"),
                new DicItem("04","教学改革经费"),
                new DicItem("99","其他"),
            };

        }
    }
}
