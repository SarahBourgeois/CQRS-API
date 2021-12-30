using System;
namespace CrushOn.Application.Commands
{
    public class CreateProductCommand
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
