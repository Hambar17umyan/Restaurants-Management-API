using DAL.Entities;

namespace DAL.Models.QueryModels;

internal sealed class AddressQueryModel
{
    public bool SelectStreetName { get; private set; } = false;

    public bool SelectAddressLine1 { get; private set; } = false;

    public bool SelectAddressLine2 { get; private set; } = false;

    public bool SelectCity { get; private set; } = false;

    public bool SelectState { get; private set; } = false;

    public bool SelectPostalCode { get; private set; } = false;

    public bool SelectCountry { get; private set; } = false;

    public Func<AddressEntity, bool>? Predicate { get; private set; }

    public AddressQueryModel()
    {
    }

    public class Builder
    {
        private readonly AddressQueryModel _model = new();

        public Builder SelectStreetName()
        {
            this._model.SelectStreetName = true;
            return this;
        }

        public Builder SelectAddressLine1()
        {
            this._model.SelectAddressLine1 = true;
            return this;
        }

        public Builder SelectAddressLine2()
        {
            this._model.SelectAddressLine2 = true;
            return this;
        }

        public Builder SelectCity()
        {
            this._model.SelectCity = true;
            return this;
        }

        public Builder SelectState()
        {
            this._model.SelectState = true;
            return this;
        }

        public Builder SelectPostalCode()
        {
            this._model.SelectPostalCode = true;
            return this;
        }

        public Builder SelectCountry()
        {
            this._model.SelectCountry = true;
            return this;
        }

        public Builder Where(Func<AddressEntity, bool> predicate)
        {
            this._model.Predicate = predicate;
            return this;
        }

        public AddressQueryModel Build()
        {
            return this._model;
        }
    }
}
