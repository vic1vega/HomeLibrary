using System.Linq;

namespace HomeLibrary.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Items.Any())
            {
                context.AddRange(
                    new Item { AuthorName = "Alejandro González Iñárritu", Cover = "https://ssl-gfx.filmweb.pl/po/65/83/586583/7749389.3.jpg", ItemId = 1, RentDate = 0, RentName = null, Title = "Zjawa", Type = Types.DVD, UserId = 0, Year = 2015, IsRent=true },
                    new Item { AuthorName = "Queen", Cover = "https://images-na.ssl-images-amazon.com/images/I/6139YfAAyBL._SS500.jpg", ItemId = 2, RentDate = 0, RentName = null, Title = "Jazz", Type = Types.CD, UserId = 0, Year = 1978, IsRent=true },
                    new Item { AuthorName = "George Orwell", Cover = "https://upload.wikimedia.org/wikipedia/commons/f/fb/Animal_Farm_-_1st_edition.jpg", ItemId = 3, RentDate = 0, RentName = null, Title = "Folwark Zwierzęcy", Type = Types.Book, UserId = 0, Year = 1945, IsRent=true }
                    );
            }
            context.SaveChanges();
        }
    }
}