namespace Domain.Infrastructure.ResultModels;

public enum ErrorType
{
    Unspecified = 500001,
    MappingError = 500002,

    PlayerByIdNotFound = 404001,
    RestaurantByIdNotFound = 404002,
    AddressByIdNotFound = 404003,
    AddressdNotFound = 404004,

    MultiplePlayersWithSameNameFound = 400001,
    RestaurantMembershipAlreadyExists = 400002,
}
