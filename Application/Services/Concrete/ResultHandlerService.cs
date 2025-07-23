using Application.Api.Common;
using Application.Services.Abstraction;
using Domain.Exceptions.ResultException;
using Domain.Exceptions.Unknown;
using Domain.Infrastructure.ResultModels;
using FluentResults;
using System.Net;

namespace Application.Services.Concrete;

public class ResultHandlerService : IResultHandlerService
{
    private readonly ICreateFailService _createFailService;
    public ResultHandlerService(ICreateFailService createFailService)
    {
        this._createFailService = createFailService;
    }

    public BindedResponse HandleResult<T>(Result<T> result)
        where T : IResponse
    {
        if (result.IsFailed)
        {
            var error = result.Errors.FirstOrDefault();
            if (error is null)
            {
                throw new FailingResultNotHaveErrorsException();
            }

            if (error is not ApplicationError appError)
            {
                throw new FirstErrorIsNotApplicationErrorException();
            }

            return this.GenerateFail(appError);
        }

        return new BindedResponse(
            HttpStatusCode.OK,
            result.Value);
    }

    private BindedResponse GenerateFail(ApplicationError error)
    {
        switch (error.Type)
        {
            case ErrorType.Unspecified:
                return this._createFailService.CreateFail(
                    HttpStatusCode.InternalServerError,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            case ErrorType.MappingError:
                return this._createFailService.CreateFail(
                    HttpStatusCode.InternalServerError,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            case ErrorType.PlayerByIdNotFound:
                return this._createFailService.CreateFail(
                    HttpStatusCode.NotFound,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            case ErrorType.RestaurantByIdNotFound:
                return this._createFailService.CreateFail(
                    HttpStatusCode.NotFound,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            case ErrorType.MultiplePlayersWithSameNameFound:
                return this._createFailService.CreateFail(
                    HttpStatusCode.BadRequest,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            case ErrorType.AddressByIdNotFound:
                return this._createFailService.CreateFail(
                    HttpStatusCode.NotFound,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            case ErrorType.AddressdNotFound:
                return this._createFailService.CreateFail(
                    HttpStatusCode.NotFound,
                    error.ShouldExposeMessage ? error.ApiMessage! : "",
                    error.Metadata);
            default:
                throw new UnknownErrorException("The enum type is not registered in result handler.");
        }
    }
}
