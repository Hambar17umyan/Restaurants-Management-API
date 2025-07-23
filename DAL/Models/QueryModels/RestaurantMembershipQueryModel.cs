using DAL.Entities;

namespace DAL.Models.QueryModels;

internal class RestaurantMembershipQueryModel
{
    public bool SelectRestaurantId { get; private set; } = false;

    public bool SelectPlayerId { get; private set; } = false;

    public bool IncludeRestaurant { get; private set; } = false;

    public bool IncludePlayer { get; private set; } = false;

    public Func<RestaurantMembershipEntity, bool>? Predicate { get; private set; } = _ => true;

    public class Builder
    {
        private readonly RestaurantMembershipQueryModel _model = new();

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

        public Builder Where(Func<RestaurantMembershipEntity, bool> predicate)
        {
            this._model.Predicate = predicate;
            return this;
        }

        public RestaurantMembershipQueryModel Build()
        {
            return this._model;
        }
    }
}
