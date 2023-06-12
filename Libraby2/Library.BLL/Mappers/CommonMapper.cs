using Libraby2.Library.BLL.DTO;
using Libraby2.Library.DAL.Entities;
using Libraby2.Library.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.BLL.Mappers
{
    public static class CommonMapper
    {
        public static BookEntity MapBookDtoToEntity(this BookDTO bookDTO)
        {
            return new BookEntity()
            {
                author = bookDTO.author,
                id = bookDTO.id,
                genre = bookDTO.genre,
                name = bookDTO.name,
                publisher = bookDTO.publisher,
                year = bookDTO.year
            };

        }

        public static BookModel MapBookDtoToModel(this BookDTO bookDTO)
        {
            return new BookModel()
            {
                author = bookDTO.author,
                id = bookDTO.id,
                genre = bookDTO.genre,
                name = bookDTO.name,
                publisher = bookDTO.publisher,
                year = bookDTO.year
            };

        }

        public static BookDTO MapBookEntityToDto(this BookEntity bookEntity)
        {
            return new BookDTO()
            {
                author = bookEntity.author,
                id = bookEntity.id,
                genre = bookEntity.genre,
                name = bookEntity.name,
                publisher = bookEntity.publisher,
                year = bookEntity.year
            };

        }

        public static List<BookDTO> MapBookListEntityToDto(this List<BookEntity> bookEntities)
        {
            List<BookDTO> bookDTOs = new List<BookDTO>();
            foreach (var item in bookEntities)
            {
                bookDTOs.Add(item.MapBookEntityToDto());
            }
            return bookDTOs;
        }

        public static BookDTO MapBookModelToDto(this BookModel bookModel)
        {
            return new BookDTO()
            {
                author = bookModel.author,
                id = bookModel.id,
                genre = bookModel.genre,
                name = bookModel.name,
                publisher = bookModel.publisher,
                year = bookModel.year
            };

        }

        public static List<BookModel> MapBookListDtoToModel(this List<BookDTO> bookDTOs)
        {
            List<BookModel> bookModels = new List<BookModel>();
            foreach (var item in bookDTOs)
            {
                bookModels.Add(item.MapBookDtoToModel());
            }
            return bookModels;
        }
    }
}
