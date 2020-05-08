namespace BL.StandardDictionary
{
    /// <summary>
    /// 教育机构举办者 JT1001-XXJYJGJBZ (GB/T 4657部分未列出明细1-7)
    /// </summary>
    public class DicOrg: DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","中央党政机关、人民团体及其他机构"),
                new DicItem("2","中央党政机关、人民团体及其他机构"),
                new DicItem("3","中央党政机关、人民团体及其他机构"),
                new DicItem("4","中央党政机关、人民团体及其他机构"),
                new DicItem("5","中央党政机关、人民团体及其他机构"),
                new DicItem("6","中央党政机关、人民团体及其他机构"),
                new DicItem("7","中央党政机关、人民团体及其他机构"),
                new DicItem("8","省与省级以下地方部门"),
                new DicItem("9","省与省级以下地方部门"),
                new DicItem("811","省级教育部门"),
                new DicItem("812","省级其他部门（党政机关）"),
                new DicItem("821","地级教育部门"),
                new DicItem("822","地级其他部门（党政机关）"),
                new DicItem("831","县级教育部门"),
                new DicItem("832","县级其他部门（党政机关）"),
                new DicItem("891","地方企业"),
                new DicItem("892","事业单位"),
                new DicItem("893","部队"),
                new DicItem("894","集体"),
                new DicItem("999","民办"),
            };
            
        }
    }
}
