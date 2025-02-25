using Tech_Library_Api.Domain.Entities;
using Tech_Library_Api.Infrastructure;
using Tech_Library_Api.Services.LoggedUser;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.UseCases.Checkouts
{
    public class RegisterBookCheckoutsUseCase
    {
        private readonly TechLibraryDbContext _db;
        private const int MAX_LOAN_DAYS = 7;
        private readonly LoggedUserService _loggedUserService;

        public RegisterBookCheckoutsUseCase(LoggedUserService loggedUserService)
        {
            _db = new TechLibraryDbContext();
            _loggedUserService = loggedUserService;
        }
        public void Execute(Guid bookId)
        {
            Validate(bookId);

            var user = _loggedUserService.GetUser();

            var entity = new Checkout
            {
                UserId = user.Id,
                BookId = bookId,
                CheckoutDate = DateTime.UtcNow,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_LOAN_DAYS)
            };

            _db.Checkouts.Add(entity);
            _db.SaveChanges();
        }

        private void Validate(Guid bookId)
        {
            var book = _db.Books.FirstOrDefault(book => book.Id == bookId);

            if (book is null)
            {
                throw new BookNotFoundException($"Livro com id {bookId} não encontrado!");
            }

            var amountBooksNotReturned = _db.Checkouts.Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            if (amountBooksNotReturned >= book.Amount)
            {
                throw new ConflictException($"Livro com id {bookId} esgotado!");
            }
        }
    }
}
