using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Models.QueryModels;

public class PlayerQueryModel
{
    public bool SelectId { get; private set; } = false;

    public bool SelectName { get; private set; } = false;

    public bool SelectDateOfBirth { get; private set; } = false;

    public bool SelectPrimaryAddressId { get; private set; } = false;

    public bool SelectAlternateAddressId { get; private set; } = false;

    public bool SelectOfficeAddressId { get; private set; } = false;

    public bool SelectPhoneNumber { get; private set; } = false;

    public bool SelectEmail { get; private set; } = false;

    public bool SelectDriverLicenseNumber { get; private set; } = false;

    public bool SelectPassportNumber { get; private set; } = false;

    public bool IncludePrimaryAddress { get; private set; } = false;

    public bool IncludeAlternateAddress { get; private set; } = false;

    public bool IncludeOfficeAddress { get; private set; } = false;

    public Expression<Func<PlayerEntity, bool>>? Predicate { get; private set; } = _ => true;

    public readonly static PlayerQueryModel Default = new PlayerQueryModel()
    {
        IncludeAlternateAddress = false,
        IncludeOfficeAddress = false,
        IncludePrimaryAddress = false,
        SelectAlternateAddressId = false,
        SelectDateOfBirth = false,
        SelectDriverLicenseNumber = false,
        SelectEmail = true,
        SelectId = true,
        SelectName = true,
        SelectOfficeAddressId = false,
        SelectPhoneNumber = true,
        SelectPrimaryAddressId = false,
        SelectPassportNumber = true,
        Predicate = _ => true
    };

    private PlayerQueryModel()
    {
    }

    public class Builder
    {
        private readonly PlayerQueryModel _model = new();

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

        public Builder SelectDateOfBirth()
        {
            this._model.SelectDateOfBirth = true;
            return this;
        }

        public Builder SelectPrimaryAddressId()
        {
            this._model.SelectPrimaryAddressId = true;
            return this;
        }

        public Builder SelectAlternateAddressId()
        {
            this._model.SelectAlternateAddressId = true;
            return this;
        }

        public Builder SelectOfficeAddressId()
        {
            this._model.SelectOfficeAddressId = true;
            return this;
        }

        public Builder SelectPhoneNumber()
        {
            this._model.SelectPhoneNumber = true;
            return this;
        }

        public Builder SelectEmail()
        {
            this._model.SelectEmail = true;
            return this;
        }

        public Builder SelectDriverLicenseNumber()
        {
            this._model.SelectDriverLicenseNumber = true;
            return this;
        }

        public Builder SelectPassportNumber()
        {
            this._model.SelectPassportNumber = true;
            return this;
        }

        public Builder IncludePrimaryAddress()
        {
            this._model.IncludePrimaryAddress = true;
            return this;
        }

        public Builder IncludeAlternateAddress()
        {
            this._model.IncludeAlternateAddress = true;
            return this;
        }

        public Builder IncludeOfficeAddress()
        {
            this._model.IncludeOfficeAddress = true;
            return this;
        }

        public Builder Where(Expression<Func<PlayerEntity, bool>> predicate)
        {
            this._model.Predicate = predicate;
            return this;
        }

        public PlayerQueryModel Build()
        {
            return this._model;
        }
    }
}
