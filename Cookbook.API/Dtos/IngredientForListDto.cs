using System;
using System.Collections.Generic;

namespace Cookbook.API.Dtos
{
    public class IngredientForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }

    }
}