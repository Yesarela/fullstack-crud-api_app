using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
