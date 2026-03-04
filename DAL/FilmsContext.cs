using Microsoft.EntityFrameworkCore;
using SklepPB.Models;

namespace SklepPB.DAL
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public DbSet<Category> Categories { get; set; }

        public FilmsContext(DbContextOptions<FilmsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Action", Desc = "Film akcji" },
                new Category { Id = 2, Name = "Comedy", Desc = "Komedia" },
                new Category { Id = 3, Name = "Drama", Desc = "Film dramatyczny" },
                new Category { Id = 4, Name = "Horror", Desc = "Straszny film" },
                new Category { Id = 5, Name = "Sci-Fi", Desc = "Film science fiction" },
                new Category { Id = 6, Name = "Romance", Desc = "Film romantyczny" }
            };

            var films = new List<Film>
            {
                new Film { Id = 1, Title = "Inception", Director = "Christopher Nolan", Desc = "Film o snach", Price = 19.99m, CategoryId = 5 },
                new Film { Id = 2, Title = "The Dark Knight", Director = "Christopher Nolan", Desc = "Film o Batmanie", Price = 14.99m, CategoryId = 1 },
                new Film { Id = 3, Title = "Forrest Gump", Director = "Robert Zemeckis", Desc = "Historia życia Forresta Gumpa", Price = 9.99m, CategoryId = 3 },
                new Film { Id = 4, Title = "The Conjuring", Director = "James Wan", Desc = "Film o duchach", Price = 12.99m, CategoryId = 4 },
                new Film { Id = 5, Title = "The Hangover", Director = "Todd Phillips", Desc = "Komedia o wieczorze kawalerskim", Price = 8.99m, CategoryId = 2 },
                new Film { Id = 6, Title = "Titanic", Director = "James Cameron", Desc = "Film o katastrofie Titanica", Price = 11.99m, CategoryId = 6 },
                new Film { Id = 7, Title = "The Matrix", Director = "The Wachowskis", Desc = "Film o wirtualnej rzeczywistości", Price = 15.99m, CategoryId = 5 },
                new Film { Id = 8, Title = "Gladiator", Director = "Ridley Scott", Desc = "Film o rzymskim gladiatorze", Price = 13.99m, CategoryId = 1 },
                new Film { Id = 9, Title = "The Shawshank Redemption", Director = "Frank Darabont", Desc = "Film o więzieniu Shawshank", Price = 10.99m, CategoryId = 3 },
                new Film { Id = 10, Title = "Get Out", Director = "Jordan Peele", Desc = "Horror o rasizmie", Price = 9.99m, CategoryId = 4 },
                // ===== ACTION (CategoryId = 1) =====
                new Film { Id = 11, Title = "Mad Max: Fury Road", Director = "George Miller", Desc = "Postapokaliptyczny pościg przez pustynię", Price = 16.99m, CategoryId = 1 },
                new Film { Id = 12, Title = "John Wick", Director = "Chad Stahelski", Desc = "Były zabójca wraca do gry", Price = 14.99m, CategoryId = 1 },
                new Film { Id = 13, Title = "Die Hard", Director = "John McTiernan", Desc = "Policjant kontra terroryści", Price = 12.99m, CategoryId = 1 },
                new Film { Id = 14, Title = "The Avengers", Director = "Joss Whedon", Desc = "Superbohaterowie ratują świat", Price = 15.99m, CategoryId = 1 },
                new Film { Id = 15, Title = "Mission: Impossible – Fallout", Director = "Christopher McQuarrie", Desc = "Agent Ethan Hunt w kolejnej misji", Price = 17.99m, CategoryId = 1 },
                new Film { Id = 16, Title = "The Raid", Director = "Gareth Evans", Desc = "Policyjny szturm na wieżowiec", Price = 11.99m, CategoryId = 1 },
                new Film { Id = 17, Title = "Casino Royale", Director = "Martin Campbell", Desc = "James Bond w nowej odsłonie", Price = 13.99m, CategoryId = 1 },
                new Film { Id = 18, Title = "Lethal Weapon", Director = "Richard Donner", Desc = "Dwóch gliniarzy przeciw mafii", Price = 10.99m, CategoryId = 1 },
                new Film { Id = 19, Title = "Top Gun: Maverick", Director = "Joseph Kosinski", Desc = "Powrót legendarnego pilota", Price = 18.99m, CategoryId = 1 },
                new Film { Id = 20, Title = "300", Director = "Zack Snyder", Desc = "Bitwa pod Termopilami", Price = 9.99m, CategoryId = 1 },

                // ===== COMEDY (CategoryId = 2) =====
                new Film { Id = 21, Title = "Superbad", Director = "Greg Mottola", Desc = "Szkolna komedia o przyjaźni", Price = 9.99m, CategoryId = 2 },
                new Film { Id = 22, Title = "Step Brothers", Director = "Adam McKay", Desc = "Dwóch dorosłych braci pod jednym dachem", Price = 8.99m, CategoryId = 2 },
                new Film { Id = 23, Title = "The Mask", Director = "Chuck Russell", Desc = "Magiczna maska zmienia życie bohatera", Price = 7.99m, CategoryId = 2 },
                new Film { Id = 24, Title = "Home Alone", Director = "Chris Columbus", Desc = "Chłopiec kontra włamywacze", Price = 10.99m, CategoryId = 2 },
                new Film { Id = 25, Title = "Dumb and Dumber", Director = "Peter Farrelly", Desc = "Dwóch przyjaciół w podróży", Price = 6.99m, CategoryId = 2 },
                new Film { Id = 26, Title = "The Grand Budapest Hotel", Director = "Wes Anderson", Desc = "Ekscentryczna komedia hotelowa", Price = 11.99m, CategoryId = 2 },
                new Film { Id = 27, Title = "21 Jump Street", Director = "Phil Lord & Christopher Miller", Desc = "Tajniacy w liceum", Price = 9.49m, CategoryId = 2 },
                new Film { Id = 28, Title = "Anchorman", Director = "Adam McKay", Desc = "Prezenter wiadomości w krzywym zwierciadle", Price = 8.49m, CategoryId = 2 },
                new Film { Id = 29, Title = "The Intern", Director = "Nancy Meyers", Desc = "Senior stażystą w startupie", Price = 10.49m, CategoryId = 2 },
                new Film { Id = 30, Title = "Bridesmaids", Director = "Paul Feig", Desc = "Druhenki w tarapatach", Price = 9.49m, CategoryId = 2 },

                // ===== DRAMA (CategoryId = 3) =====
                new Film { Id = 31, Title = "The Green Mile", Director = "Frank Darabont", Desc = "Strażnik więzienny i niezwykły skazaniec", Price = 12.99m, CategoryId = 3 },
                new Film { Id = 32, Title = "Fight Club", Director = "David Fincher", Desc = "Podziemny klub walki", Price = 11.99m, CategoryId = 3 },
                new Film { Id = 33, Title = "The Godfather", Director = "Francis Ford Coppola", Desc = "Historia mafijnej rodziny", Price = 14.99m, CategoryId = 3 },
                new Film { Id = 34, Title = "A Beautiful Mind", Director = "Ron Howard", Desc = "Historia genialnego matematyka", Price = 10.99m, CategoryId = 3 },
                new Film { Id = 35, Title = "Whiplash", Director = "Damien Chazelle", Desc = "Ambicja młodego perkusisty", Price = 9.99m, CategoryId = 3 },
                new Film { Id = 36, Title = "Joker", Director = "Todd Phillips", Desc = "Narodziny złoczyńcy", Price = 13.99m, CategoryId = 3 },
                new Film { Id = 37, Title = "The Pianist", Director = "Roman Polanski", Desc = "Losy pianisty w czasie wojny", Price = 11.49m, CategoryId = 3 },
                new Film { Id = 38, Title = "Parasite", Director = "Bong Joon-ho", Desc = "Konflikt dwóch rodzin", Price = 12.49m, CategoryId = 3 },
                new Film { Id = 39, Title = "The Social Network", Director = "David Fincher", Desc = "Historia powstania Facebooka", Price = 10.49m, CategoryId = 3 },
                new Film { Id = 40, Title = "There Will Be Blood", Director = "Paul Thomas Anderson", Desc = "Historia bezwzględnego przedsiębiorcy", Price = 12.99m, CategoryId = 3 },

                // ===== HORROR (CategoryId = 4) =====
                new Film { Id = 41, Title = "Hereditary", Director = "Ari Aster", Desc = "Mroczna tajemnica rodziny", Price = 11.99m, CategoryId = 4 },
                new Film { Id = 42, Title = "It", Director = "Andy Muschietti", Desc = "Dzieci kontra klaun", Price = 10.99m, CategoryId = 4 },
                new Film { Id = 43, Title = "A Nightmare on Elm Street", Director = "Wes Craven", Desc = "Koszmar z Freddy'm", Price = 8.99m, CategoryId = 4 },
                new Film { Id = 44, Title = "The Exorcist", Director = "William Friedkin", Desc = "Egzorcyzmy młodej dziewczyny", Price = 9.99m, CategoryId = 4 },
                new Film { Id = 45, Title = "The Ring", Director = "Gore Verbinski", Desc = "Tajemnicza kaseta wideo", Price = 8.49m, CategoryId = 4 },
                new Film { Id = 46, Title = "The Babadook", Director = "Jennifer Kent", Desc = "Potwór z dziecięcej książki", Price = 7.99m, CategoryId = 4 },
                new Film { Id = 47, Title = "Insidious", Director = "James Wan", Desc = "Rodzina nawiedzana przez duchy", Price = 9.49m, CategoryId = 4 },
                new Film { Id = 48, Title = "Sinister", Director = "Scott Derrickson", Desc = "Pisarz odkrywa przerażające nagrania", Price = 8.49m, CategoryId = 4 },
                new Film { Id = 49, Title = "The Witch", Director = "Robert Eggers", Desc = "Rodzina w obliczu mrocznych sił", Price = 9.99m, CategoryId = 4 },
                new Film { Id = 50, Title = "Midsommar", Director = "Ari Aster", Desc = "Niepokojący festiwal w Szwecji", Price = 12.49m, CategoryId = 4 },

                // ===== SCI-FI (CategoryId = 5) =====
                new Film { Id = 51, Title = "Interstellar", Director = "Christopher Nolan", Desc = "Podróż międzygwiezdna", Price = 17.99m, CategoryId = 5 },
                new Film { Id = 52, Title = "Blade Runner 2049", Director = "Denis Villeneuve", Desc = "Łowca androidów", Price = 14.99m, CategoryId = 5 },
                new Film { Id = 53, Title = "Arrival", Director = "Denis Villeneuve", Desc = "Kontakt z obcą cywilizacją", Price = 12.99m, CategoryId = 5 },
                new Film { Id = 54, Title = "Star Wars: A New Hope", Director = "George Lucas", Desc = "Początek kosmicznej sagi", Price = 13.99m, CategoryId = 5 },
                new Film { Id = 55, Title = "The Terminator", Director = "James Cameron", Desc = "Cyborg z przyszłości", Price = 10.99m, CategoryId = 5 },
                new Film { Id = 56, Title = "Avatar", Director = "James Cameron", Desc = "Konflikt na planecie Pandora", Price = 15.99m, CategoryId = 5 },
                new Film { Id = 57, Title = "Ex Machina", Director = "Alex Garland", Desc = "Eksperyment ze sztuczną inteligencją", Price = 9.99m, CategoryId = 5 },
                new Film { Id = 58, Title = "Dune", Director = "Denis Villeneuve", Desc = "Walka o pustynną planetę", Price = 16.99m, CategoryId = 5 },
                new Film { Id = 59, Title = "Edge of Tomorrow", Director = "Doug Liman", Desc = "Pętla czasowa w wojnie z obcymi", Price = 11.99m, CategoryId = 5 },
                new Film { Id = 60, Title = "Gravity", Director = "Alfonso Cuarón", Desc = "Walka o przetrwanie w kosmosie", Price = 10.99m, CategoryId = 5 },

                // ===== ROMANCE (CategoryId = 6) =====
                new Film { Id = 61, Title = "The Notebook", Director = "Nick Cassavetes", Desc = "Romantyczna historia miłosna", Price = 9.99m, CategoryId = 6 },
                new Film { Id = 62, Title = "Pride & Prejudice", Director = "Joe Wright", Desc = "Miłość i konwenanse", Price = 8.99m, CategoryId = 6 },
                new Film { Id = 63, Title = "La La Land", Director = "Damien Chazelle", Desc = "Miłość i marzenia w Los Angeles", Price = 12.99m, CategoryId = 6 },
                new Film { Id = 64, Title = "Before Sunrise", Director = "Richard Linklater", Desc = "Romantyczna noc w Wiedniu", Price = 7.99m, CategoryId = 6 },
                new Film { Id = 65, Title = "Me Before You", Director = "Thea Sharrock", Desc = "Miłość w trudnych okolicznościach", Price = 8.49m, CategoryId = 6 },
                new Film { Id = 66, Title = "Notting Hill", Director = "Roger Michell", Desc = "Romans z gwiazdą filmową", Price = 9.49m, CategoryId = 6 },
                new Film { Id = 67, Title = "A Star Is Born", Director = "Bradley Cooper", Desc = "Miłość i muzyka", Price = 11.99m, CategoryId = 6 },
                new Film { Id = 68, Title = "The Fault in Our Stars", Director = "Josh Boone", Desc = "Miłość dwojga nastolatków", Price = 8.99m, CategoryId = 6 },
                new Film { Id = 69, Title = "Crazy, Stupid, Love", Director = "Glenn Ficarra & John Requa", Desc = "Miłosne perypetie kilku par", Price = 9.99m, CategoryId = 6 },
                new Film { Id = 70, Title = "Love Actually", Director = "Richard Curtis", Desc = "Kilka historii miłosnych", Price = 10.49m, CategoryId = 6 },
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Film>().HasData(films);
        }
    }
}
