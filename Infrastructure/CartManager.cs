using SklepPB.DAL;

namespace SklepPB.Infrastructure
{
    public static class CartManager
    {
        public static void AddToCart(ISession session, FilmsContext db, int filmId)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(f => f.Film.Id == filmId);

            if(thisFilm != null)
            {
                thisFilm.Quantity++;
            }
            else
            {
                var newCartItem = db.Films.Find(filmId);

                if(newCartItem != null)
                {
                    var cartItem = new CartItem()
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Value = newCartItem.Price
                    };

                    cart.Add(cartItem);
                }
            }

            SessionHelper.SetObjectAsJson(session, Consts.CartSessionKey, cart);
        }

        public static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(session, Consts.CartSessionKey);

            if(cart == null)
            {
                cart = new();
            }

            return cart;

        }

        public static decimal? GetCartTotalValue(ISession session)
        {
            var cart = GetItems(session);

            return cart.Sum(c => c.Quantity * c.Value);
        }

        public static int RemoveFromCart(ISession session, int filmId)
        {
            var cart = GetItems(session);
            var thisFilm = cart.Find(f => f.Film.Id == filmId);

            if(thisFilm == null) return 0;

            int count = 0;

            if (thisFilm.Quantity > 1)
            {
                 thisFilm.Quantity--;
                 count = thisFilm.Quantity;
            }
            else
            {
                 cart.Remove(thisFilm);
            }
            
            session.SetObjectAsJson(Consts.CartSessionKey, cart);
            return count;
        }

    }
}
