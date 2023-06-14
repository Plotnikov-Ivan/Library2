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
                year = bookDTO.year,
                count = bookDTO.count,
            };

        }

        public static JournalEntity MapJournalDtoToEntity(this JournalDTO jrDTO)
        {
            return new JournalEntity()
            {
                id = jrDTO.id,
                name = jrDTO.name,
                freq = jrDTO.freq,
                count = jrDTO.count,
                year = jrDTO.year,
                publisher = jrDTO.publisher,
                number= jrDTO.number,
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
                year = bookDTO.year,
                count = bookDTO.count,
            };

        }



        public static JournalModel MapJournalDtoToModel(this JournalDTO jrDTO)
        {
            if (jrDTO != null)
            {
                return new JournalModel()
                {
                    freq = jrDTO.freq,
                    id = jrDTO.id,
                    number = jrDTO.number,
                    name = jrDTO.name,
                    publisher = jrDTO.publisher,
                    year = jrDTO.year,
                    count = jrDTO.count,
                };
            }
            return null;
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
                year = bookEntity.year,
                count = bookEntity.count,
            };

        }

        public static JournalDTO MapJournalEntityToDto(this JournalEntity jrEntity)
        {
            if (jrEntity != null)
            {
                return new JournalDTO()
                {
                    id = jrEntity.id,
                    name = jrEntity.name,
                    freq = jrEntity.freq,
                    count = jrEntity.count,
                    year = jrEntity.year,
                    publisher = jrEntity.publisher,
                    number = jrEntity.number,
                };
            }
            return null;
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


        public static List<JournalDTO> MapJournalListEntityToDto(this List<JournalEntity> JournalEntities)
        {
            List<JournalDTO> JournalDTOs = new List<JournalDTO>();
            foreach (var item in JournalEntities)
            {
                JournalDTOs.Add(item.MapJournalEntityToDto());
            }
            return JournalDTOs;
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
                year = bookModel.year,
                count = bookModel.count,
            };

        }


        public static JournalDTO MapJournalModelToDto(this JournalModel jrModel)
        {
            return new JournalDTO()
            {
                id = jrModel.id,
                name = jrModel.name,
                freq = jrModel.freq,
                count = jrModel.count,
                year = jrModel.year,
                publisher = jrModel.publisher,
                number = jrModel.number,
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

        public static List<JournalModel> MapJournalListDtoToModel(this List<JournalDTO> jrDTOs)
        {
            List<JournalModel> jrModels = new List<JournalModel>();
            foreach (var item in jrDTOs)
            {
                jrModels.Add(item.MapJournalDtoToModel());
            }
            return jrModels;
        }
    }
}
