using DAL.Entities;

namespace DAL.Models.QueryModels;

internal class PlayerFavoriteRestaurantQueryModel
{
    public bool SelectRestaurantId { get; private set; } = false;

    public bool SelectPlayerId { get; private set; } = false;

    public bool IncludeRestaurant { get; private set; } = false;

    public bool IncludePlayer { get; private set; } = false;

    public Func<PlayerFavoriteRestaurantEntity, bool>? Predicate { get; private set; } = _ => true;

    public class Builder
    {
        private readonly PlayerFavoriteRestaurantQueryModel _model = new();

        public Builder SelectRestaurantId()
        {
            this._model.SelectRestaurantId = true;
            return this;
        }

        public Builder SelectPlayerId()
        {
            this._model.SelectPlayerId = true;
            return this;
        }

        public Builder IncludeRestaurant()
        {
            this._model.IncludeRestaurant = true;
            return this;
        }

        public Builder IncludePlayer()
        {
            this._model.IncludePlayer = true;
            return this;
        }

        public Builder Where(Func<PlayerFavoriteRestaurantEntity, bool> predicate)
        {
            this._model.Predicate = predicate;
            return this;
        }

        public PlayerFavoriteRestaurantQueryModel Build()
        {
            return this._model;
        }
    }
}
