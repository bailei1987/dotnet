using BL.Common;

namespace BL.Regions
{
    public static class RegionExtension
    {
        public static RegionMini ToRegionMini(this Region region)
        {
            if (region.Codes.Count > 0) region.ReFillByCodes();
            else if (region.Names.Count > 0) region.ReFillByNames();
            else region.ReFillByLongName();
            return new RegionMini
            { 
                Codes=region.Codes,
                Names=region.Names
            };
        }
        public static Region ToRegion(this RegionMini region)
        {
            return new Region
            {
                Codes = region.Codes,
                Names = region.Names
            };
        }
    }
}
