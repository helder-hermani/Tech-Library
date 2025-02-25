using Tech_Library_Api.Infrastructure;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;

namespace Tech_Library_Api.UseCases.Books.Filter
{
    public class FilterBooksUseCase
    {
        private const int PAGE_SIZE = 10;
        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var skip = (request.PageNumber - 1) * PAGE_SIZE;
            var db = new TechLibraryDbContext();

            //var books = db
            //    .Books
            //    .OrderBy(book => book.Title).ThenBy(book => book.Author)
            //    .Skip(skip)
            //    .Take(PAGE_SIZE)
            //    .ToList();

            var query = db.Books.AsQueryable();
            query = query.OrderBy(book => book.Title).ThenBy(book => book.Author);

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(book => book.Title.ToLower().Contains(request.Title.ToLower()));
            }

            if (request.PageNumber > 0)
            {
                query = query.Skip(skip).Take(PAGE_SIZE);
            }

            var books = query.ToList();

            var qtdLivros = query.Count();
            //var qtdLivros = db.Books.Count();

            return new ResponseBooksJson()
            {
                PaginationJson = new ResponsePaginationJson
                {
                    PageNumber = request.PageNumber,
                    PageSize = PAGE_SIZE,
                    TotalCount = qtdLivros,
                },
                Books = books.Select(book => new ResponseBookJson
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                }).ToList()
            };
        }
    }
}
