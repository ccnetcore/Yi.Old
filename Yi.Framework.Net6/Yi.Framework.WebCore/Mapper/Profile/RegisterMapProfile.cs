using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.Mapper
{
    public class RegisterMapProfile : Profile
    {
        //添加你的实体映射关系和出参字段
        //public RegisterMapProfile()
        //{
        //    #region 排班信息
        //    CreateMap<JToken, SchedulHeadViewModel>()
        //        .ForMember(dest => dest.HospitalId,
        //            options => options.MapFrom(c => c.SelectToken("Hospital_ID")))
        //        .ForMember(dest => dest.BranchId,
        //            options => options.MapFrom(c => c.SelectToken("Branch_ID")))
        //        .ForMember(dest => dest.SchedulId,
        //            options => options.MapFrom(c => c.SelectToken("ScheduHeadID")));
        //}
    }
}
