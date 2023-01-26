using AutoMapper;
using brewing.Models;
using brewing.Requests;
using System;

namespace brewing.Helpers
{
    public class AutoMapperHelper: Profile
    {
        public AutoMapperHelper()
        {
            //CreateRecipeRequest
            CreateMap<CreateRecipeRequest, Recipe>();

            //UpdateRecipeRequest
            CreateMap<UpdateRecipeRequest, Recipe>();
            
        }
    }
}
