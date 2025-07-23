using DAL.Entities;
using DAL.Models.QueryModels;
using DAL.Services.QueryProcessing.Abstraction;

namespace DAL.Services.QueryProcessing.Concrete;

public class PlayerQueryProcessor : IPlayerQueryProcessor
{
    public IQueryable<PlayerEntity> Process(IQueryable<PlayerEntity> collection, PlayerQueryModel query)
    {
        if (query.Predicate != null)
        {
            collection = collection.Where(query.Predicate);
        }

        var projection = collection.Select(player => new PlayerEntity
        {
            Id = query.SelectId ? player.Id : default,
            Name = query.SelectName ? player.Name : null!,
            DateOfBirth = query.SelectDateOfBirth ? player.DateOfBirth : default,
            PrimaryAddressId = query.SelectPrimaryAddressId ? player.PrimaryAddressId : null,
            AlternateAddressId = query.SelectAlternateAddressId ? player.AlternateAddressId : null,
            OfficeAddressId = query.SelectOfficeAddressId ? player.OfficeAddressId : null,
            PhoneNumber = query.SelectPhoneNumber ? player.PhoneNumber : null!,
            Email = query.SelectEmail ? player.Email : null!,
            DriverLicenseNumber = query.SelectDriverLicenseNumber ? player.DriverLicenseNumber : null!,
            PassportNumber = query.SelectPassportNumber ? player.PassportNumber : null!,
            PrimaryAddress = query.IncludePrimaryAddress ? player.PrimaryAddress : null,
            AlternateAddress = query.IncludeAlternateAddress ? player.AlternateAddress : null,
            OfficeAddress = query.IncludeOfficeAddress ? player.OfficeAddress : null
        });

        return projection;
    }
}
