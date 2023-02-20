namespace Library.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            var books = new List<Book>
            {
                new Book
                {
                    Title = "Lord of the rings",
                    Cover = "Empty",
                    Content = "The saga of a group of sometimes reluctant heroes who set forth to save their world from consummate evil.",
                    Author = "J.R.R. Tolkien",
                    Genre = "Adventure"
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Cover = "Empty",
                    Content = "Pride and Prejudice follows the turbulent relationship between Elizabeth Bennet, the daughter of a country gentleman, and Fitzwilliam Darcy, a rich aristocratic landowner.",
                    Author = "Jane Austen",
                    Genre = "Novel",
                },
                new Book
                {
                    Title = "The Picture of Dorian Gray",
                    Cover = "Empty",
                    Content = "The Picture of Dorian Gray tells about a young man named Dorian Gray who has a portrait painted of himself.",
                    Author = "Oscar Wilde",
                    Genre = "Novel",
                },
                new Book
                {
                    Title = "The Great Gatsby",
                    Cover = "Empty",
                    Content = "Set in Jazz Age New York, it tells the tragic story of Jay Gatsby, a self-made millionaire, and his pursuit of Daisy Buchanan, a wealthy young woman whom he loved in his youth.",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Tragedy",
                },
                new Book
                {
                    Title = "Gone with the Wind",
                    Cover = "Empty",
                    Content = "Gone With the Wind is a story about civil war, starvation, rape, murder, heartbreak and slavery.",
                    Author = "Margaret Mitchell",
                    Genre = "Novel",
                },
                new Book
                {
                    Title = "Animal Farm",
                    Cover = "Empty",
                    Content = "It tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.",
                    Author = "George Orwell",
                    Genre = "Satire",
                },
                new Book
                {
                    Title = "The Lion, the Witch and the Wardrobe",
                    Cover = "Empty",
                    Content = "Four kids travel through a wardrobe to the land of Narnia and learn of their destiny to free it with the guidance of a mystical lion.",
                    Author = "C. S. Lewis",
                    Genre = "Fantasy",
                },
                new Book
                {
                    Title = "Dracula",
                    Cover = "Empty",
                    Content = "Jonathan Harker, a young English lawyer, travels to Castle Dracula in the Eastern European country of Transylvania to conclude a real estate transaction with a nobleman named Count Dracula.",
                    Author = "Bram Stoker",
                    Genre = "Horror",
                },
                new Book
                {
                    Title = "And Then There Were None",
                    Cover = "Empty",
                    Content = "And Then There Were None is the story of ten strangers, each lured to Indian Island by a mysterious host",
                    Author = "Agatha Christie",
                    Genre = "Mystery",
                },
                new Book
                {
                    Title = "Frankenstein",
                    Cover = "Empty",
                    Content = "Frankenstein tells the story of gifted scientist Victor Frankenstein who succeeds in giving life to a being of his own creation.",
                    Author = "Mary Shelley",
                    Genre = "Horror",
                }
            };

            context.Books.AddRange(books);

            var reviews = new List<Review>
            {
                new Review
                {
                    Message = "Good book",
                    Reviewer = "Reviewer 1",
                    Book = books[0],
                },
                new Review
                {
                    Message = "That's perfect!",
                    Reviewer = "Reviewer 2",
                    Book = books[0],
                },
                new Review
                {
                    Message = "Good job",
                    Reviewer = "Reviewer 3",
                    Book = books[0],
                },
                new Review
                {
                    Message = "It сouldn’t be better!",
                    Reviewer = "Reviewer 1",
                    Book = books[1],
                },
                new Review
                {
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Reviewer = "Reviewer 3",
                    Book = books[1],
                },
                new Review
                {
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Reviewer = "Reviewer 13",
                    Book = books[2],
                },
                new Review
                {
                    Message = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Reviewer = "Reviewer 1",
                    Book = books[2],
                },
                new Review
                {
                    Message = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ",
                    Reviewer = "Reviewr 3",
                    Book = books[3],
                },
                new Review
                {
                    Message = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Reviewer = "Reviewr 2",
                    Book = books[4],
                },
                new Review
                {
                    Message = "Sed enim ut sem viverra aliquet eget sit amet.",
                    Reviewer = "Reviewr 4",
                    Book = books[5],
                },
                new Review
                {
                    Message = "Tristique magna sit amet purus gravida quis blandit turpis cursus.",
                    Reviewer = "Reviewr 7",
                    Book = books[6],
                },
                new Review
                {
                    Message = "Odio pellentesque diam volutpat commodo sed egestas egestas fringilla phasellus.",
                    Reviewer = "Reviewr 2",
                    Book = books[7],
                },
                new Review
                {
                    Message = "Et netus et malesuada fames ac turpis egestas integer.",
                    Reviewer = "Reviewr 1",
                    Book = books[8],
                },
                new Review
                {
                    Message = "Pretium fusce id velit ut.",
                    Reviewer = "Reviewr 13",
                    Book = books[9],
                },
                new Review
                {
                    Message = "Consectetur adipiscing elit ut aliquam.",
                    Reviewer = "Reviewr 5",
                    Book = books[9],
                }
            };

            context.Reviews.AddRange(reviews);

            var ratings = new List<Rating>
            {
                new Rating
                {
                    Score = 5,
                    Book = books[0],
                },
                new Rating
                {
                    Score = 5,
                    Book = books[0],
                },
                new Rating
                { 
                    Score = 4,
                    Book = books[1], 
                },
                new Rating
                {
                    Score = 5,
                    Book = books[1],
                },
                new Rating
                {
                    Score = 4,
                    Book = books[1],
                },
                new Rating
                {
                    Score = 3,
                    Book = books[2],
                },
                new Rating
                {
                    Score = 4,
                    Book = books[3],
                },
                new Rating
                {
                    Score = 4,
                    Book = books[4],
                },
                new Rating
                {
                    Score = 5,
                    Book = books[5],
                },
                new Rating
                {
                    Score = 5,
                    Book = books[6],
                },
                new Rating
                {
                    Score = 3,
                    Book = books[7],
                },
                new Rating
                {
                    Score = 5,
                    Book = books[8],
                },
                new Rating
                {
                    Score = 4,
                    Book = books[9],
                },
            };

            context.Ratings.AddRange(ratings);

            context.SaveChanges();
        }
    }
}
