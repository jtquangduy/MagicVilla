using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> {
                 new VillaDTO{Id=1,Name="Pool View",Sqrt=100,Occupancy=4},
                 new VillaDTO{Id=2,Name="Beach View",Sqrt=300,Occupancy=3}
            };
    }
}