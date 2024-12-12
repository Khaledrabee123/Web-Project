using System.Runtime.InteropServices;
using AutoMapper;
using book_store.models.database;
using store.Models.DTO;

namespace book_store.models.mapingprofile
{
    public class Mappingprofile:Profile
    {
        public Mappingprofile() {

            CreateMap<Book, BookDTO>().ReverseMap();


        }
    }
}
