using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Common.Mapping
{
    //public interface IMapperForm
    //{
    //    void Mapping(Profile profile) => profile.CreateMap(typeof(T),GetType());
    //}
    public interface IMapperForm<TSource>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TSource),GetType());
    }
}
