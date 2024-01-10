﻿using FluentValidation;

namespace SwiftLink.Application.UseCases.Links.GenerateCommand;

public class GenerateShortCodeValidator : AbstractValidator<GenerateShortCodeCommand>
{
    public GenerateShortCodeValidator()
    {
        RuleFor(x => x.Url)
            .NotNull().WithMessage(Constants.Link.UrlMustBeSent)
            .Must(BeAValidUrl).WithMessage(Constants.Link.InvalidUrlFormat);
    }

    private bool BeAValidUrl(string url)
        => UrlFormatChecker.UrlRegex().IsMatch(url);
}