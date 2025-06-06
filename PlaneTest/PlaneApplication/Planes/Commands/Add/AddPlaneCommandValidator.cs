﻿using FluentValidation;
using PlaneDomain.PlaneAggregate;

namespace PlaneApplication.Planes.Commands.Add;

public class AddPlaneCommandValidator : AbstractValidator<AddPlaneCommand>
{
	public AddPlaneCommandValidator()
	{
		RuleFor(c => c.Name).NotEmpty();
		RuleFor(c => c.WeightKg).NotNull().GreaterThan(0);
		RuleFor(c => c.MaxWeight).NotNull().GreaterThan(0);
		RuleFor(c => c.MaxSpeed).NotNull().GreaterThan(0);
		RuleFor(c => c.Type)
			.NotEmpty()
			.Must(PlaneType.BeAValidPlaneType)
			.WithMessage("Type must be one these: Glider, PrivatePlane, PassengerPlane, TransportPlane, JetFighter");

		When(x => !PlaneType.IsGlider(x.Type), () =>
		{
			RuleFor(x => x.MotorName).NotEmpty();
			RuleFor(x => x.Power)
				.NotNull()
				.GreaterThan(0);
			RuleFor(x => x.Consumption)
				.NotNull()
				.GreaterThan(0);
		});
	}
}
