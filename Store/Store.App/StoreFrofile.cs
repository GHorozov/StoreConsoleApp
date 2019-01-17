using AutoMapper;
using Store.App.Models;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.App
{
    public class StoreFrofile : Profile
    {
        public StoreFrofile()
        {
            CreateMap<User, User>();

            CreateMap<Product, ProductDetailsDto>()
                .ForMember(x => x.Author, opt => opt.MapFrom(a => a.Author.Username));

            CreateMap<Product, ProductDto>()
               .ForMember(x => x.Author, opt => opt.MapFrom(a => a.Author.Username));

            CreateMap<Comment, CommentDto>()
                .ForMember(x => x.Author, opt => opt.MapFrom(a => a.Author.Username));
        }
    }
}
