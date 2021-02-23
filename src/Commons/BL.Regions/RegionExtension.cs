using BL.Common;

namespace BL.Regions
{
    public static class RegionExtension
    {
        public static RegionMini ToRegionMini(this Region region)
        {
            if (region.Codes.Count > 0) _ = region.ReFillByCodes();
            else if (region.Names.Count > 0) _ = region.ReFillByNames();
            else region.ReFillByLongName();
            return new()
            {
                Codes = region.Codes,
                Names = region.Names
            };
        }
        public static Region ToRegion(this RegionMini region)
        {
            return new()
            {
                Codes = region.Codes,
                Names = region.Names
            };
        }
    }
}
