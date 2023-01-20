using AutoMapper;
using brewing.Models;
using brewing.Requests;

namespace brewing.Helpers;
{
    public class AutoMapperHelper: Profile
    {
        public AutoMapperHelper()
        {
            //CreateRecipeRequest
            CreateMap<CreateRecipeRequest, Recipe>();

            //UpdateRecipeRequest
            CreateMap<UpdateRecipeRequest, Recipe>()
                .ForAllMembers(x=>x.Condition)
        }
    }
}
