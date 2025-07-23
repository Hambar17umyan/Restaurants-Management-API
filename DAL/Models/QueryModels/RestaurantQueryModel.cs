using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Models.QueryModels;

public class RestaurantQueryModel
{
    public static readonly RestaurantQueryModel Default = new()
    {
        IncludeAddress = false,
        SelectId = true,
        SelectName = true,
        SelectAddressId = true,
        SelectPhoneNumber = true,
        SelectOpenningTime = true,
        SelectClosingTime = true,
        Predicate = _ => true,
    };

    public bool SelectId { get; private set; } = false;

    public bool SelectName { get; private set; } = false;

    public bool SelectAddressId { get; private set; } = false;

    public bool SelectPhoneNumber { get; private set; } = false;

    public bool SelectOpenningTime { get; private set; } = false;

    public bool SelectClosingTime { get; private set; } = false;

    public bool IncludeAddress { get; private set; } = false;

    public Expression<Func<RestaurantEntity, bool>>? Predicate { get; private set; } = null;

    private RestaurantQueryModel() 
    {
    }

    public class Builder
    {
        private readonly RestaurantQueryModel _model = new();

        public Builder SelectId()
        {
            this._model.SelectId = true;
            return this;
        }

        public Builder SelectName()
        {
            this._model.SelectName = true;
            return this;
        }

        public Builder SelectAddressId()
        {
            this._model.SelectAddressId = true;
            return this;
        }

        public Builder SelectPhoneNumber()
        {
            this._model.SelectPhoneNumber = true;
            return this;
        }

        public Builder SelectOpenningTime()
        {
            this._model.SelectOpenningTime = true;
            return this;
        }

        public Builder SelectClosingTime()
        {
            this._model.SelectClosingTime = true;
            return this;
        }

        public Builder IncludeAddress()
        {
            this._model.IncludeAddress = true;
            return this;
        }

        public Builder Where(Expression<Func<RestaurantEntity, bool>> predicate)
        {
            this._model.Predicate = predicate;
            return this;
        }

        public RestaurantQueryModel Build()
        {
            return this._model;
        }
    }
}
