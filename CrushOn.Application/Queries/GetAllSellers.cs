using System;
using System.Collections.Generic;
using CrushOn.Core.EntitiesModel;
using MediatR;

namespace CrushOn.Application.Queries
{
    public class GetAllSellers  : IRequest<List<SellerModel>>
    {
    }
}
