using System;
using System.Collections.Generic;
using CrushOn.Core.EntitiesModel;
using MediatR;

namespace CrushOn.Application.Queries
{
    public class GetAllProducts : IRequest<List<ProductModel>>
    {

    }
}
